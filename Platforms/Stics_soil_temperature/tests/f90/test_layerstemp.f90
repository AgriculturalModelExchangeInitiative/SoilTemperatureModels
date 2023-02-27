PROGRAM test_layerstemp

   USE layers_temp_mod

   REAL    ::  tempprofile(10)
   real ::  layers_depth1(5),layers_depth2(3)
   REAL    ::  layers_temp1(size(layers_depth1)), layers_temp2(size(layers_depth2))


   tempprofile = (/9.5, 10., 10.1, 10.2, 10.3, 10.4, 10.5, 10.6, 10.7, 10.8/)
   
   ! test 1: 5 identical layers
   layers_depth1 = (/2, 4, 6, 8, 10/)
   layers_temp1 = 0.

   call model_layers_temp(tempprofile, layers_depth1, layers_temp1)

   !layers_temp1:
   !  9.75000000       10.1499996       10.3500004       10.5500002       10.7500000
   print *, "layers_temp1 estimated :"
   print *, layers_temp1

   ! test 2: 3 differents layers 
   layers_depth2 = (/2, 7, 10/)
   layers_temp2 = 0.

   call model_layers_temp(tempprofile, layers_depth2, layers_temp2)
   
   !layers_temp2:
   ! 9.75000000       10.3000002       10.6999998 
   print *, "layers_temp2 estimated :"
   print *, layers_temp2

   ! test 1: 5 layers, not consistent with temp profile
   ! must fail
   layers_depth1 = (/2, 4, 6, 8, 9/)
   call model_layers_temp(tempprofile, layers_depth1, layers_temp1)

END PROGRAM
