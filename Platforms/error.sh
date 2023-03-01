# ERRORS
# When fixed, move the cmd to convert.sh
cyml -p DSSAT_EPICST_standalone r 
cyml -p DSSAT_EPICST_standalone openalea

cyml -p DSSAT_ST_standalone r 

cd SQ_Soil_Temperature
cyml -c SQ_Soil_Temperature SQ_Soil_Temperature bioma
cd ..

cyml -p Simplace_Soil_Temperature r

cd Bioma
cyml -c BiomaSurfacePartonSoilSWATC BiomaSurfacePartonSoilSWATC bioma
cd ..