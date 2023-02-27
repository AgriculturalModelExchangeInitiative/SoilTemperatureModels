PROGRAM test_tempprofile

   USE temp_profile_mod

   REAL :: tempamp
   REAL :: thermamp
   REAL :: temp_profile_t1(10)
   REAL :: canopy_temp_t1
   REAL :: min_temp
   REAL :: max_temp
   REAL :: temp_profile(size(temp_profile_t1))

   min_temp = 8
   max_temp = 18
   tempamp = max_temp - min_temp
   thermamp = 8.22857842E-02
   temp_profile_t1 = (/9.5, 10., 10.1, 10.2, 10.3, 10.4, 10.5, 10.6, 10.7, 10.8/)
   canopytemp_t1 = 15.

   tempprofile = 0.

   call model_temp_profile(tempamp, thermamp, temp_profile_t1, &
                         canopy_temp_t1, min_temp, temp_profile)

   !tempprofile:
   ! 8.20798206 8.80348587 9.02749538 9.24092007 9.44459438 9.63928986 9.82571602 10.0045242
   ! 10.1763172 10.3416500 
   print *, "tempprofile estimated :"
   print *, tempprofile

END PROGRAM
