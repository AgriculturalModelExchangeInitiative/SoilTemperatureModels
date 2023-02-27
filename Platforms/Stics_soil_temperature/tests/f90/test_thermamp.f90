PROGRAM test_thermamp
   USE therm_amp_mod
   REAL:: thermdif
   REAL:: tempwave_freq
   REAL:: thermamp
   print *, "--------test_thermamp-------"
   thermdif = 5.37e-3
   tempwave_freq = 7.272e-5
   ! Without tempwave_freq
   call model_therm_amp(therm_diff=thermdif, therm_amp=thermamp)
   print *, "thermamp estimated (no tempwave_freq arg.) :"
   print *, thermamp
   ! With tempwave_freq
   call model_therm_amp(thermdif, tempwave_freq, thermamp)
   ! thermamp: 8.228578e-2
   print *, "thermamp estimated :"
   print *, thermamp
END PROGRAM
