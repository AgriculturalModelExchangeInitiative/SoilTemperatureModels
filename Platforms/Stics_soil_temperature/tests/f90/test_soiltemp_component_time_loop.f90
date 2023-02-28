program test_soiltemp
   use soil_temp_mod
   use layers_temp_mod
   
   integer, parameter :: max_days_num = 731

   ! Structure for storing input data
   type meteo_
      integer, dimension(max_days_num) :: year, month, day, doy
      real, dimension(max_days_num)  ::  tmin, tmax, tmoy
      real, dimension(max_days_num) :: tcultmin, tcultmax, tcult
   end type meteo_


   real :: soil_depth
   real :: layer_thick(5)
   real  :: prev_temp_profile(300)
   real  :: prev_canopy_temp
   real  :: min_canopy_temp
   real  :: max_canopy_temp
   real  :: min_temp
   real :: therm_diff
   real:: temp_wave_freq
   real  :: temp_profile(300)
   integer :: soil_dim, i, nb_days

   integer :: layers_nb
   real, allocatable :: layer_temp(:)
   real, allocatable :: daily_layer_temp(:,:)



   type(meteo_) :: meteo


   ! zero
   prev_temp_profile(:) = 0.0
   layer_thick(:) = 0.0
   prev_canopy_temp = 0.0
   min_canopy_temp = 0.
   max_canopy_temp = 0.
   min_temp = 0.0
   therm_diff = 0.0
   temp_wave_freq = 0.0
   temp_profile(:) = 0.

   ! Reading daily temperatures data from a Stics output file (maize) 
   open(12,file = 'data/mod_smaize.sti',status = 'unknown')

   read(12,*)

   do i = 1, max_days_num
    read (12,*,err=250,end=80) meteo%year(i), meteo%month(i), meteo%day(i), & 
                               meteo%doy(i), meteo%tcult(i), meteo%tmin(i), &
                               meteo%tcultmax(i), meteo%tcultmin(i), &
                               meteo%tmoy(i), meteo%tmax(i)
   end do

80    continue

   ! Calculating days number
250 nb_days = i - 1
    close(12)


   ! Initializing layers thickness array
   ! Using the maize soil in the example usm maize
   layer_thick = (/25.0, 30.0, 35.0, 30.0, 0.0/)

   ! Layers number
   call get_layers_number(layer_thick, layers_nb)

   ! Soil depth array (in cm)
   call get_soil_depth(layer_thick, soil_depth)

   ! Number of elemental layers (1 cm)
   soil_dim = int(soil_depth)

   ! In Stics the soil temperature profile and the previous day canopy temperature
   ! are initialized with the mean temperature of day 1
   prev_temp_profile(1:soil_dim) = meteo%tmoy(1)
   prev_canopy_temp = meteo%tmoy(1)
   
   ! Parameters initialization
   therm_diff = 5.37e-3
   temp_wave_freq = 7.272e-5

   ! Allocating mean temperature array (nb_days * nb layers)
   allocate(daily_layer_temp(nb_days, layers_nb))
   allocate(layer_temp(layers_nb))
   daily_layer_temp(:,:) = NaN
   layer_temp(:) = NaN


   do i = 1,nb_days
      call model_soil_temp(prev_temp_profile(1:soil_dim), prev_canopy_temp, &
                          meteo%tcultmin(i), meteo%tcultmax(i),   &
                          meteo%tmin(i), therm_diff, temp_wave_freq, &
                          temp_profile(1:soil_dim))

       ! TODO: write the temperature in a file!                

       ! Updating canopy temperature of the previous day
       prev_canopy_temp = meteo%tcult(i)
       ! Updating canopy temperature of the previous day: 
       ! now done in model_temp_profile routine
       ! prev_temp_profile(1:soil_dim) = temp_profile(1:soil_dim)
       

       ! Calculating meansoil layers temp
       call model_layers_temp(prev_temp_profile(1:soil_dim), &
                              layer_thick(1:layers_nb), layer_temp)

       ! Storing mean layer temp per day
       daily_layer_temp(i, :) = layer_temp

       ! TODO: write daily layers temperature in a file
       write(*,*) meteo%doy(i), daily_layer_temp(i, :)

   end do

  

   ! Deallocating arrays
   if (ALLOCATED(daily_layer_temp)) then
      deallocate(daily_layer_temp)
   end if

   if (ALLOCATED(layer_temp)) then
      deallocate(layer_temp)
   end if

end program
