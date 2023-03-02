
PLATFORMS=`python -c "from pycropml.transpiler.main import languages; print(' '.join([l for l in languages if l!='check']))"`
echo 'LANGUAGES: '$PLATFORMS

PKG=DSSAT_EPICST_standalone
echo 'Tranform '$PKG

cp -R ../$PKG .
rm -rf $PKG/doc $PKG/src $PKG/test $PKG/crop2ml

# Create Crop2ML from DSSAT
cyml -c $PKG $PKG dssat

# Generate the code: 
# To have the list of languages use:
# 
cyml -p $PKG $PLATFORMS

echo 'DONE '$PKG

#####################################################
# Step 2 
PKG=DSSAT_ST_standalone
echo 'Tranform '$PKG
cp -R ../$PKG .
rm -rf $PKG/doc $PKG/src $PKG/test $PKG/crop2ml

cyml -c $PKG $PKG dssat
# Generate the code: 
cyml -p $PKG $PLATFORMS

echo 'DONE '$PKG

#####################################################
# Step 3
 PKG=SQ_Soil_Temperature
echo 'Tranform '$PKG
cp -R ../$PKG .
rm -rf $PKG/doc $PKG/src $PKG/test $PKG/crop2ml

cyml -c $PKG $PKG bioma
# Generate the code: 
cyml -p $PKG $PLATFORMS

echo 'DONE '$PKG

#####################################################
# Step 4
 PKG=BiomaSurfacePartonSoilSWATC
echo 'Tranform '$PKG
cp -R ../$PKG .
rm -rf $PKG/doc $PKG/src $PKG/test $PKG/crop2ml

cyml -c $PKG $PKG bioma
# Generate the code: 
cyml -p $PKG $PLATFORMS

echo 'DONE '$PKG

#####################################################
# Step 5
 PKG=BiomaSurfacePartonSoilSWATHourlyPartonC
echo 'Tranform '$PKG
cp -R ../$PKG .
rm -rf $PKG/doc $PKG/src $PKG/test $PKG/crop2ml

cyml -c $PKG $PKG bioma
# Generate the code: 
cyml -p $PKG $PLATFORMS

echo 'DONE '$PKG

#####################################################
# Step 6
 PKG=BiomaSurfaceSWATSoilSWATC
echo 'Tranform '$PKG
cp -R ../$PKG .
rm -rf $PKG/doc $PKG/src $PKG/test $PKG/crop2ml

cyml -c $PKG $PKG bioma
# Generate the code: 
cyml -p $PKG $PLATFORMS

echo 'DONE '$PKG

#####################################################
# Step 7
 PKG=Simplace_Soil_Temperature
echo 'Tranform '$PKG
cp -R ../$PKG .
rm -rf $PKG/doc $PKG/src $PKG/test $PKG/crop2ml

cyml -c $PKG $PKG simplace
# Generate the code: 
cyml -p $PKG $PLATFORMS

echo 'DONE '$PKG

#####################################################
# Step 8
 PKG=Stics_soil_temperature
echo 'Tranform '$PKG
cp -R ../$PKG .
rm -rf $PKG/doc $PKG/src $PKG/test $PKG/crop2ml

cyml -c $PKG $PKG stics
# Generate the code: 
cyml -p $PKG $PLATFORMS

echo 'DONE '$PKG

