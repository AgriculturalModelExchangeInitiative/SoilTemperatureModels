# Soil Temperature from ApSimX

The Soil Temperature model is from ApSimX.
The C# code can be retrieve on github (https://github.com/APSIMInitiative/ApsimX/tree/master/Models/Soils/SoilTemp).

A detailled description of the model can be found on the ApSim website (https://www.apsim.info/documentation/model-documentation/soil-modules-documentation/soiltemp/).

## Layout
- campbell_apsim : contains the original C# code from Apsim implementing the campbell model
- campbell_python : full Python implementation of the Campbell model from Apsim
- standalone : Python code used to run simulations
- tutorial : Notebook example illustrating the Campbell model
- Campbell : Crop2ML package for Campbell translated in various languages and platforms



## Documentation of the work in progress
- The transpilation from python code to crop2ml package works
- The transpilation from crop2ml to languages/platforms still has some problems :

     - [x] py
     - [x] cs
     - [x] f90
     - [x] java
     - [x] apsim
     - [x] bioma
     - [x] dssat
     - [x] openalea
     - [x] simplace
     - [x] stics
     - [x] sirius
     - [x] cpp / monica
