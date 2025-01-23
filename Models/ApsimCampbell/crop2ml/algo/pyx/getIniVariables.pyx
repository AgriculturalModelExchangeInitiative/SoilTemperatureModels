def getIniVariables(float instrumentHeight,
         float instrumHeight,
         float defaultInstrumentHeight):
    if instrumHeight > 0.00001:
        instrumentHeight=instrumHeight
    else:
        instrumentHeight=defaultInstrumentHeight
    return instrumentHeight