def getIniVariables(float instrumHeight,
         float defaultInstrumentHeight,
         float instrumentHeight):
    if instrumHeight > 0.00001:
        instrumentHeight=instrumHeight
    else:
        instrumentHeight=defaultInstrumentHeight
    return instrumentHeight