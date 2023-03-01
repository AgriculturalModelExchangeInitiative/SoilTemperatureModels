# Create Crop2ML from DSSAT 
cyml -c DSSAT_EPICST_standalone DSSAT_EPICST_standalone dssat
# Generate the code: 
# ERROR : 
# cyml -p DSSAT_EPICST_standalone r 
# cyml -p DSSAT_EPICST_standalone openalea
cyml -p DSSAT_EPICST_standalone simplace sirius  stics bioma

cyml -c DSSAT_ST_standalone DSSAT_ST_standalone dssat
# Generate the code: 
# ERROR : r 
# cyml -p DSSAT_ST_standalone r 
cyml -p DSSAT_ST_standalone openalea
cyml -p DSSAT_ST_standalone simplace  stics bioma

# Sirius: Do not knw how to generate the crop2ml files
cd SQ_Soil_Temperature
#cyml -c SQ_Soil_Temperature SQ_Soil_Temperature bioma
cyml -p SQ_Soil_Temperature simplace dssat  stics  openalea
cd ..

# Simplace
cyml -c Simplace_Soil_Temperature Simplace_Soil_Temperature simplace
cyml -p Simplace_Soil_Temperature bioma dssat  stics  openalea

# STICS
cyml -c Stics_soil_temperature Stics_soil_temperature stics
cyml -p Stics_soil_temperature bioma dssat openalea simplace r

# Bioma
cd Bioma
cyml -p BiomaSurfacePartonSoilSWATC stics dssat openalea simplace r
cd ..