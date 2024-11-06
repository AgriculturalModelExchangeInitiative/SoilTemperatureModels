# -*- python -*-
#
#       amei.soillTemperature
#
#       Copyright 2006 - 2024 INRIA - CIRAD - INRA  
#
#       Distributed under the Cecill-C License.
#       See accompanying file LICENSE.txt or copy at
#           http://www.cecill.info/licences/Licence_CeCILL-C_V1-en.html
# 
#       OpenAlea WebSite : http://openalea.gforge.inria.fr
#
################################################################################
""" Data Nodes """

__license__ = "Cecill-C"
__revision__ = " $Id$ "

from openalea.core import Node, ISequence, IEnumStr, IInt
import standalone
import model

class Configuration(Node):
    """
    Python array
    """
    WST_Names = ['Gainesville/USA', 'Muncheberg/GER', 'Cali/COL', 'Lusignan/FR', 'Maricopa/USA', 'Montpellier/FR', 'QuebecCity/CA']
    WST_IDs = ['USGA', 'DEMU', 'COCA', 'FRLU', 'USMA', 'FRMO', 'CAQC']
    SOIL_IDs = ['SICL', 'SILO', 'SALO', 'SAND']
    AWCs = "0.0, 0.25, 0.5, 0.75, 1.0".split(',')
    LAIDs = "0, 2, 7".split(',')

    def __init__(self):
        Node.__init__(self)

        #self.typedict = dict(list(zip(self.codename, self.typecodes)))
        self.add_input(name='WeatherStation', interface=IEnumStr(self.WST_Names), 
                       value=self.WST_Names)
        self.add_input(name='SoilType', interface=IEnumStr(self.SOIL_IDs), value='SICL')
        self.add_input(name='SoilWaterContent', interface=IEnumStr(self.AWCs), value='0.0')
        self.add_input(name='LAI', interface=IEnumStr(self.LAIDs), value='0')

        self.add_output(name='config',)

    def __call__(self, inputs):
        """ inputs is the list of input values """
        wst = inputs[0] 
        i = self.WST_Names.index(wst)
        wst_id= self.WST_IDs[i]
        soil = inputs[1]
        water_content = float(inputs[2])
        lai = int(inputs[3])

        print(f'station {wst_id} | soil {soil} | water {water_content} | LAI {lai}')

        trt = standalone.Treatment()
        config = trt(wst_id, soil, water_content, lai)

        return (config,)

class Models(Node):
    """
    Python array
    """
    Models = model.Model.models()

    def __init__(self):
        Node.__init__(self)

        #self.typedict = dict(list(zip(self.codename, self.typecodes)))
        self.add_input(name='Model', interface=IEnumStr(self.Models), 
                       value=list(self.Models)[0])
        self.add_input(name='Config', interface=None, value=None)
        self.add_input(name='steps', interface=IInt(min=-1, max=365*30), value=30)


        self.add_output(name='soiltemperature',)

    def __call__(self, inputs):
        """ inputs is the list of input values """
        model = inputs[0] 
        config = inputs[1]
        nb_steps = inputs[2]

        my_model = self.Models[model]()
        res = my_model.run(config=config, nb_steps=nb_steps)

        self.set_caption(model)


        #res = standalone.simulate(config.weather, config.soil,
        #          config.AWC, config.albedo, config.XLAT, config.TAMP, config.TAV, config.LAI, nb_layers=config.nb_layers)
        
        return (res,)

class Columns(Node):
    """
    
    """ 
    columns = "TSLD TSLX TSLN".split()
    def __init__(self):
        Node.__init__(self)

        self.add_input(name='dataframe')
        self.add_input(name='column', interface=IEnumStr(self.columns), value='TSLD' )
        self.add_input(name='Layer', interface=IInt(min=0, max=10), value=1)

        self.add_output(name='dates',)
        self.add_output(name='soilTemp',)


    def __call__(self, inputs):
        """ inputs is the list of input values """

        df = inputs[0]
        col = inputs[1]
        layer = inputs[2]

        if layer:
            df = df[df.Layer==layer]

        dates = df.Date
        res = df[col]

        return dates, res

