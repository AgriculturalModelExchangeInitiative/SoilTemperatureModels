# Soil Temperature Models
AMEI Workshop on Soil Temperature Models Exchange between different platforms

Models have been adapted to meet the Crop2ML requirements

## DSSAT

### Create crop2ml repository from DSSAT models
```bash
cyml -c DSSAT_EPICST_standalone DSSAT_EPICST_standalone dssat 
```

### Convert it to Simplace openalea and stics (example)
```bash
cyml -p DSSAT_EPICST_standalone simplace openalea stics

```
## SiriusQuality

### Convert the result to various paltforms
```bash
cd SQ_soil_temperature
cyml -p SQ_soil_temperature py stics simplace 
```

## Simplace

### Convert the result to various paltforms
```bash
cyml -p Simplace_Soil_Temperature py stics openalea sirius
```
