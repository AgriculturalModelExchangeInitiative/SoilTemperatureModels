PROGRAM test_soiltemp
   
   USE soil_temp_mod
   

   REAL  :: soiltemp_t1(10)
   REAL  :: canopytemp_t1
   REAL  :: min_temp, canopy_min_temp
   REAL  :: canopy_max_temp
   REAL :: thermdif
   REAL:: tempwave_freq
   REAL  :: soiltemp(size(soiltemp_t1))


   soiltemp_t1 = (/9.5, 10., 10.1, 10.2, 10.3, 10.4, 10.5, 10.6, 10.7, 10.8/)
   canopytemp_t1 = 15.
   min_temp = 8
   canopy_min_temp = 8
   canopy_max_temp = 18
   thermdif = 5.37e-3
   tempwave_freq = 7.272e-5
   soiltemp = 0.

   call model_soil_temp(soiltemp_t1, canopytemp_t1, canopy_min_temp, &
                       canopy_max_temp, min_temp, thermdif, tempwave_freq, soiltemp)

   !soiltemp:
   ! 8.20798206 8.80348587 9.02749538 9.24092007 9.44459438 9.63928986 9.82571602 10.0045242
   ! 10.1763172 10.3416500
   print *, "soiltemp estimated :"
   print *, soiltemp

END PROGRAM
