# Soil Temperature Models
AMEI Workshop on Soil Temperature Models Exchange between different platforms

Models have been adapted to meet the Crop2ML requirements

## DSSAT -> simplace

### Create crop2ml repository from DSSAT models
```bash
cyml -c DSSAT_EPICST_standalone DSSAT_EPICST_standalone dssat 
```

### Convert it to Simplace openalea and stics
cyml -p DSSAT_EPICST_standalone simplace openalea stics
