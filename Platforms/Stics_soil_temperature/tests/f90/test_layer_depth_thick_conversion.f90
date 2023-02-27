PROGRAM test_layers

   USE layers_temp_mod

   !REAL    ::  tempprofile(10)
   real ::  layers_depth1(5),layers_depth2(3)
   real ::  layers_thick1(5),layers_thick2(3)
   real ::  soil_depth1, soil_depth2
   

   !--------------------------------------------------------------------------
   ! Testing depth to thickness
   print *, "Testing depth to thickness"

   ! test 0: last layer missing depth
   layers_depth1 = (/2, 4, 6, 8, 0/)

   call layer_depth2thickness(layers_depth1, layers_thick1)
  
   !layers_thick1:
   !  2    2    2   2   0
   print *, "layers_thick estimated : last depth is null"
   print *, layers_thick1

   ! test 0: last layer missing depth
   layers_depth1 = (/2, 4, 6, 0, 0/)

   call layer_depth2thickness(layers_depth1, layers_thick1)

!layers_thick1:
   !  2    2    2   0   0
   print *, "layers_thick estimated : 2 last depth is null"
   print *, layers_thick1
   


   ! test 1: 5 identical layers
   layers_depth1 = (/2, 4, 6, 8, 10/)

   call layer_depth2thickness(layers_depth1, layers_thick1)

   !layers_thick1:
   !  2    2    2   2   2
   print *, "layers_thick estimated :"
   print *, layers_thick1

   ! test 2: 3 differents layers 
   layers_depth2 = (/2, 7, 10/)

   call layer_depth2thickness(layers_depth2, layers_thick2)
   
   !layers_thick2:
   ! 2       5     3  
   print *, "layers_thick2 estimated :"
   print *, layers_thick2

   !--------------------------------------------------------------------------
   ! Testing thickness to depth
   print *, "Testing thickness to depth"
   layers_thick1 = (/2, 4, 6, 8, 10/)

   call layer_thickness2depth(layers_thick1, layers_depth1)

   !layers_depth:
   !  2    6    12   20   30
   print *, "layers_depth estimated :"
   print *, layers_depth1

   layers_thick2 = (/2, 7, 10/)

   call layer_thickness2depth(layers_thick2, layers_depth2)

   !layers_depth:
   !  2    9    19
   print *, "layers_depth estimated :"
   print *, layers_depth2


   !----------------------------------------------------
   ! Testing layers thickness to soil depth
   call get_soil_depth(layers_thick1, soil_depth1)

   !soil depth:
   !  30
   print *, "soil depth estimated :"
   print *, soil_depth1

   call get_soil_depth(layers_thick2, soil_depth2)

   !soil depth:
   !  19
   print *, "soil depth estimated :"
   print *, soil_depth2

END PROGRAM
