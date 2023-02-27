PROGRAM test_tempamp
   USE temp_amp_mod
   REAL:: min_temp
   REAL:: max_temp
   REAL:: tempamp
   print *, "--------test_tempamp-------"
   min_temp = 8
   max_temp = 18
   call model_temp_amp(min_temp, max_temp, tempamp)
   !tempamp: 10.
   print *, "tempamp estimated :"
   print *, tempamp
END PROGRAM
