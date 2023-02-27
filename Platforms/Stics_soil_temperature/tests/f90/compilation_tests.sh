

# Test temp_amp
gfortran ./../../src/Tempamp.f90 test_tempamp.f90 -o test_tempamp

# Test therm_amp
gfortran ./../../src/Thermamp.f90 test_thermamp.f90 -o test_thermamp

# Test temp_profile
gfortran ./../../src/Tempprofile.f90 test_tempprofile.f90 -o test_temprofile

# Test conversion layers depth / thick
gfortran ./../../src/Layerstemp.f90 test_layer_depth_thick_conversion.f90 \
-o test_layer_conversion

# Test layers temp calculation 
gfortran ./../../src/Layerstemp.f90 test_layerstemp.f90 -o test_layerstemp

# Test soil temp component
gfortran ./../../src/SoilTempComponent.f90 ./../../src/Layerstemp.f90 ./../../src/Tempamp.f90 \
./../../src/Thermamp.f90 ./../../src/Tempprofile.f90 test_soiltemp_component.f90 \
-o test_soiltemp_comp

# Test (inputs/oututs from Stics, maize example)
gfortran ./../../src/SoilTempComponent.f90 ./../../src/Layerstemp.f90 ./../../src/Tempamp.f90 \
./../../src/Thermamp.f90 ./../../src/Tempprofile.f90 test_soiltemp_component_time_loop.f90 \
-o test_soiltemp_dailyloop