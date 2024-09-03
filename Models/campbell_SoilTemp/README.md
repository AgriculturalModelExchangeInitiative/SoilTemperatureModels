# Soil Temperature from ApSimX

The Soil Temperature model is from ApSimX.
The C# code can be retrieve on github (https://github.com/APSIMInitiative/ApsimX/tree/master/Models/Soils/SoilTemp).

A detailled description of the model can be found on the ApSim website (https://www.apsim.info/documentation/model-documentation/soil-modules-documentation/soiltemp/).

## ROADMAP

### Provide a C# standalone model of the recent version in APSIM (Teiki)
- Define key functions as unit components
- Test the model on a given dataset
- Extract input / output 

### Provide a Python standalone model of the recent version in APSIM (Christophe)
- Use the sdame decomposition for C# and Python
- Test the model
- Write the Crop2ML metainformation interface from Python documentation 



## Tricks for the conversion


Array.ConstrainedCopy(soilTempIO, SURFACEnode, soilTemp, 0, numNodes);
->
soilTemp[0:numNodes] = soilTempIO[SURFACEnode:SURFACEnode+numNodes]

offsetDayOfYear : use datetime (date - timedelta).(day of the year)
