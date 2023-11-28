# Soil Temperature from ApSimX

The Soil Temperature model is from ApSimX.
The C# code can be retrieve on github (https://github.com/APSIMInitiative/ApsimX/tree/master/Models/Soils/SoilTemp).

A detailled description of the model can be found on the ApSim website (https://www.apsim.info/documentation/model-documentation/soil-modules-documentation/soiltemp/).

## ROADMAP

ApSIM Soil Temperature implements a modified version of Campbell without matrices and linear algebra.

* Extract input / output 
* Translate the CS code into Python/Notebook
* Test it on simple input
* Translate it into Crop2ML


## Tricks for the conversion


Array.ConstrainedCopy(soilTempIO, SURFACEnode, soilTemp, 0, numNodes);
->
soilTemp[0:numNodes] = soilTempIO[SURFACEnode:SURFACEnode+numNodes]

offsetDayOfYear : use datetime (date - timedelta).(day of the year)

# TODO 
- dampingDepth