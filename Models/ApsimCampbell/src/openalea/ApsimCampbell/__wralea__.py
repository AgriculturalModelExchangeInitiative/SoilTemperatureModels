
# This file has been generated at Tue Jan  7 16:42:35 2025

from openalea.core import *


__name__ = 'amei.dssat_.soiltemp'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['Soiltemp']


__all__ = ['soiltemperature_model_soiltemperature', 'Soiltemp']



soiltemperature_model_soiltemperature = Factory(name='SoilTemperature',
                authors='AMEI Consortium (wralea authors)',
                description=' Soil Temperature ',
                category='Unclassified',
                nodemodule='soiltemperature',
                nodeclass='model_soiltemperature',
                inputs=[{'name': 'weather_MinT', 'interface': IFloat, 'value': 0}, {'name': 'weather_MaxT', 'interface': IFloat, 'value': 0}, {'name': 'weather_MeanT', 'interface': IFloat, 'value': 0}, {'name': 'weather_Tav', 'interface': IFloat, 'value': 0}, {'name': 'weather_Amp', 'interface': IFloat, 'value': 0}, {'name': 'weather_AirPressure', 'interface': IFloat, 'value': 0}, {'name': 'weather_Wind', 'interface': IFloat, 'value': 0}, {'name': 'weather_Latitude', 'interface': IFloat, 'value': 0}, {'name': 'weather_Radn', 'interface': IFloat, 'value': 0}, {'name': 'clock_Today_DayOfYear', 'interface': IInt, 'value': 0}, {'name': 'microClimate_CanopyHeight', 'interface': IFloat, 'value': 0}, {'name': 'physical_Thickness', 'interface': ISequence, 'value': 0}, {'name': 'physical_BD', 'interface': ISequence, 'value': 0}, {'name': 'ps', 'interface': IFloat, 'value': 0}, {'name': 'physical_Rocks', 'interface': ISequence, 'value': 0}, {'name': 'physical_ParticleSizeSand', 'interface': ISequence, 'value': 0}, {'name': 'physical_ParticleSizeSilt', 'interface': ISequence, 'value': 0}, {'name': 'physical_ParticleSizeClay', 'interface': ISequence, 'value': 0}, {'name': 'organic_Carbon', 'interface': ISequence, 'value': 0}, {'name': 'waterBalance_SW', 'interface': ISequence, 'value': 0}, {'name': 'waterBalance_Eos', 'interface': IFloat, 'value': 0}, {'name': 'waterBalance_Eo', 'interface': IFloat, 'value': 0}, {'name': 'waterBalance_Es', 'interface': IFloat, 'value': 0}, {'name': 'waterBalance_Salb', 'interface': IFloat, 'value': 0}, {'name': 'Thickness', 'interface': ISequence, 'value': 0}, {'name': 'InitialValues', 'interface': ISequence, 'value': 0}, {'name': 'DepthToConstantTemperature', 'interface': IFloat, 'value': 10000}, {'name': 'timestep', 'interface': IFloat, 'value': 86400.0}, {'name': 'latentHeatOfVapourisation', 'interface': IFloat, 'value': 2465000}, {'name': 'stefanBoltzmannConstant', 'interface': IFloat, 'value': 5.67e-08}, {'name': 'airNode', 'interface': IFloat, 'value': 0}, {'name': 'surfaceNode', 'interface': IInt, 'value': 1}, {'name': 'topsoilNode', 'interface': IInt, 'value': 2}, {'name': 'numPhantomNodes', 'interface': IInt, 'value': 5}, {'name': 'constantBoundaryLayerConductance', 'interface': IFloat, 'value': 20}, {'name': 'numIterationsForBoundaryLayerConductance', 'interface': IInt, 'value': 1}, {'name': 'defaultTimeOfMaximumTemperature', 'interface': IFloat, 'value': 14.0}, {'name': 'defaultInstrumentHeight', 'interface': IFloat, 'value': 1.2}, {'name': 'bareSoilRoughness', 'interface': IFloat, 'value': 57}, {'name': 'doInitialisationStuff', 'interface': IBool, 'value': 'False'}, {'name': 'internalTimeStep', 'interface': IFloat, 'value': 0}, {'name': 'timeOfDaySecs', 'interface': IFloat, 'value': 0}, {'name': 'numNodes', 'interface': IInt, 'value': 0}, {'name': 'numLayers', 'interface': IInt, 'value': 0}, {'name': 'nodeDepth', 'interface': ISequence, 'value': 0}, {'name': 'thermCondPar1', 'interface': ISequence, 'value': 0}, {'name': 'thermCondPar2', 'interface': ISequence, 'value': 0}, {'name': 'thermCondPar3', 'interface': ISequence, 'value': 0}, {'name': 'thermCondPar4', 'interface': ISequence, 'value': 0}, {'name': 'volSpecHeatSoil', 'interface': ISequence, 'value': 0}, {'name': 'soilTemp', 'interface': ISequence, 'value': 0}, {'name': 'morningSoilTemp', 'interface': ISequence, 'value': 0}, {'name': 'heatStorage', 'interface': ISequence, 'value': 0}, {'name': 'thermalConductance', 'interface': ISequence, 'value': 0}, {'name': 'thermalConductivity', 'interface': ISequence, 'value': 0}, {'name': 'boundaryLayerConductance', 'interface': IFloat, 'value': 0}, {'name': 'newTemperature', 'interface': ISequence, 'value': 0}, {'name': 'airTemperature', 'interface': IFloat, 'value': 0}, {'name': 'maxTempYesterday', 'interface': IFloat, 'value': 0}, {'name': 'minTempYesterday', 'interface': IFloat, 'value': 0}, {'name': 'soilWater', 'interface': ISequence, 'value': 0}, {'name': 'minSoilTemp', 'interface': ISequence, 'value': 0}, {'name': 'maxSoilTemp', 'interface': ISequence, 'value': 0}, {'name': 'aveSoilTemp', 'interface': ISequence, 'value': 0}, {'name': 'aveSoilWater', 'interface': ISequence, 'value': 0}, {'name': 'thickness', 'interface': ISequence, 'value': 0}, {'name': 'bulkDensity', 'interface': ISequence, 'value': 0}, {'name': 'rocks', 'interface': ISequence, 'value': 0}, {'name': 'carbon', 'interface': ISequence, 'value': 0}, {'name': 'sand', 'interface': ISequence, 'value': 0}, {'name': 'pom', 'interface': IFloat, 'value': 0}, {'name': 'silt', 'interface': ISequence, 'value': 0}, {'name': 'clay', 'interface': ISequence, 'value': 0}, {'name': 'soilRoughnessHeight', 'interface': IFloat, 'value': 0}, {'name': 'instrumentHeight', 'interface': IFloat, 'value': 0}, {'name': 'netRadiation', 'interface': IFloat, 'value': 0}, {'name': 'canopyHeight', 'interface': IFloat, 'value': 0}, {'name': 'instrumHeight', 'interface': IFloat, 'value': 0}, {'name': 'nu', 'interface': IFloat, 'value': 0.6}, {'name': 'boundarLayerConductanceSource', 'interface': IStr, 'value': 'calc'}, {'name': 'netRadiationSource', 'interface': IStr, 'value': 'calc'}, {'name': 'MissingValue', 'interface': IFloat, 'value': 99999}, {'name': 'soilConstituentNames', 'interface': None, 'value': ['Rocks', 'OrganicMatter', 'Sand', 'Silt', 'Clay', 'Water', 'Ice', 'Air']}],
                outputs=[{'name': 'heatStorage', 'interface': ISequence}, {'name': 'instrumentHeight', 'interface': IFloat}, {'name': 'minSoilTemp', 'interface': ISequence}, {'name': 'maxSoilTemp', 'interface': ISequence}, {'name': 'aveSoilTemp', 'interface': ISequence}, {'name': 'volSpecHeatSoil', 'interface': ISequence}, {'name': 'soilTemp', 'interface': ISequence}, {'name': 'morningSoilTemp', 'interface': ISequence}, {'name': 'newTemperature', 'interface': ISequence}, {'name': 'thermalConductivity', 'interface': ISequence}, {'name': 'thermalConductance', 'interface': ISequence}, {'name': 'boundaryLayerConductance', 'interface': IFloat}, {'name': 'soilWater', 'interface': ISequence}, {'name': 'doInitialisationStuff', 'interface': IBool}, {'name': 'maxTempYesterday', 'interface': IFloat}, {'name': 'minTempYesterday', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




Soiltemp = CompositeNodeFactory(name='Soiltemp',
                             description=('\n'
 '\n'
 '    Soiltemp model\n'
 '    -Version: 2.0  -Time step: 1.0\n'
 '    Authors: Cyrille\n'
 '    Reference: None\n'
 '    Institution: INRAE\n'
 '    ExtendedDescription: Soil Temperature\n'
 '    ShortDescription: Soil Temperature\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': ISequence, 'name': 'Thickness'},
   {'interface': ISequence, 'name': 'thermalConductance'},
   {'interface': IFloat, 'name': 'weather_MaxT'},
   {  'interface': IInt,
      'name': 'numIterationsForBoundaryLayerConductance',
      'value': 1},
   {'interface': ISequence, 'name': 'newTemperature'},
   {'interface': ISequence, 'name': 'thermCondPar3'},
   {'interface': IFloat, 'name': 'instrumentHeight'},
   {'interface': ISequence, 'name': 'aveSoilWater'},
   {'interface': IFloat, 'name': 'defaultInstrumentHeight', 'value': 1.2},
   {'interface': ISequence, 'name': 'thermalConductivity'},
   {'interface': ISequence, 'name': 'silt'},
   {'interface': IFloat, 'name': 'weather_Radn'},
   {'interface': ISequence, 'name': 'bulkDensity'},
   {'interface': IFloat, 'name': 'latentHeatOfVapourisation', 'value': 2465000},
   {'interface': IFloat, 'name': 'microClimate_CanopyHeight'},
   {'interface': IFloat, 'name': 'weather_MinT'},
   {'interface': ISequence, 'name': 'physical_ParticleSizeClay'},
   {'interface': IFloat, 'name': 'airNode'},
   {'interface': IFloat, 'name': 'netRadiation'},
   {'interface': IFloat, 'name': 'ps'},
   {'interface': ISequence, 'name': 'rocks'},
   {'interface': IInt, 'name': 'numLayers'},
   {'interface': ISequence, 'name': 'minSoilTemp'},
   {'interface': IFloat, 'name': 'instrumHeight'},
   {'interface': ISequence, 'name': 'soilTemp'},
   {'interface': IFloat, 'name': 'weather_Wind'},
   {'interface': ISequence, 'name': 'physical_ParticleSizeSand'},
   {'interface': IBool, 'name': 'doInitialisationStuff', 'value': 'False'},
   {'interface': IFloat, 'name': 'canopyHeight'},
   {'interface': IFloat, 'name': 'boundaryLayerConductance'},
   {  'interface': IFloat,
      'name': 'defaultTimeOfMaximumTemperature',
      'value': 14.0},
   {'interface': ISequence, 'name': 'soilWater'},
   {'interface': IStr, 'name': 'netRadiationSource', 'value': 'calc'},
   {'interface': IFloat, 'name': 'waterBalance_Eos'},
   {'interface': IFloat, 'name': 'maxTempYesterday'},
   {'interface': IFloat, 'name': 'weather_MeanT'},
   {'interface': ISequence, 'name': 'clay'},
   {'interface': ISequence, 'name': 'thickness'},
   {'interface': IFloat, 'name': 'weather_Latitude'},
   {'interface': IFloat, 'name': 'weather_Amp'},
   {'interface': IFloat, 'name': 'timestep', 'value': 86400.0},
   {'interface': ISequence, 'name': 'maxSoilTemp'},
   {'interface': IInt, 'name': 'topsoilNode', 'value': 2},
   {'interface': IFloat, 'name': 'MissingValue', 'value': 99999},
   {'interface': IFloat, 'name': 'pom'},
   {'interface': ISequence, 'name': 'physical_BD'},
   {'interface': IFloat, 'name': 'timeOfDaySecs'},
   {'interface': ISequence, 'name': 'carbon'},
   {'interface': ISequence, 'name': 'physical_Thickness'},
   {'interface': IFloat, 'name': 'soilRoughnessHeight'},
   {'interface': ISequence, 'name': 'heatStorage'},
   {'interface': IInt, 'name': 'numPhantomNodes', 'value': 5},
   {'interface': ISequence, 'name': 'thermCondPar4'},
   {'interface': ISequence, 'name': 'nodeDepth'},
   {'interface': ISequence, 'name': 'aveSoilTemp'},
   {'interface': IFloat, 'name': 'waterBalance_Salb'},
   {'interface': IFloat, 'name': 'minTempYesterday'},
   {'interface': IInt, 'name': 'surfaceNode', 'value': 1},
   {  'interface': IStr,
      'name': 'boundarLayerConductanceSource',
      'value': 'calc'},
   {'interface': ISequence, 'name': 'thermCondPar2'},
   {'interface': ISequence, 'name': 'physical_ParticleSizeSilt'},
   {'interface': IInt, 'name': 'numNodes'},
   {'interface': IInt, 'name': 'clock_Today_DayOfYear'},
   {'interface': IFloat, 'name': 'waterBalance_Eo'},
   {'interface': IFloat, 'name': 'DepthToConstantTemperature', 'value': 10000},
   {  'interface': IFloat,
      'name': 'constantBoundaryLayerConductance',
      'value': 20},
   {'interface': IFloat, 'name': 'nu', 'value': 0.6},
   {'interface': ISequence, 'name': 'waterBalance_SW'},
   {'interface': IFloat, 'name': 'waterBalance_Es'},
   {'interface': IFloat, 'name': 'weather_Tav'},
   {'interface': ISequence, 'name': 'volSpecHeatSoil'},
   {'interface': IFloat, 'name': 'bareSoilRoughness', 'value': 57},
   {'interface': IFloat, 'name': 'stefanBoltzmannConstant', 'value': 5.67e-08},
   {'interface': ISequence, 'name': 'physical_Rocks'},
   {'interface': ISequence, 'name': 'InitialValues'},
   {'interface': IFloat, 'name': 'weather_AirPressure'},
   {'interface': ISequence, 'name': 'thermCondPar1'},
   {'interface': ISequence, 'name': 'sand'},
   {'interface': ISequence, 'name': 'morningSoilTemp'},
   {'interface': ISequence, 'name': 'organic_Carbon'},
   {  'interface': None,
      'name': 'soilConstituentNames',
      'value': [  'Rocks',
                  'OrganicMatter',
                  'Sand',
                  'Silt',
                  'Clay',
                  'Water',
                  'Ice',
                  'Air']},
   {'interface': IFloat, 'name': 'airTemperature'},
   {'interface': IFloat, 'name': 'internalTimeStep'}],
                             outputs=[  {'interface': ISequence, 'name': 'heatStorage'},
   {'interface': IFloat, 'name': 'instrumentHeight'},
   {'interface': ISequence, 'name': 'minSoilTemp'},
   {'interface': ISequence, 'name': 'maxSoilTemp'},
   {'interface': ISequence, 'name': 'aveSoilTemp'},
   {'interface': ISequence, 'name': 'volSpecHeatSoil'},
   {'interface': ISequence, 'name': 'soilTemp'},
   {'interface': ISequence, 'name': 'morningSoilTemp'},
   {'interface': ISequence, 'name': 'newTemperature'},
   {'interface': ISequence, 'name': 'thermalConductivity'},
   {'interface': ISequence, 'name': 'thermalConductance'},
   {'interface': IFloat, 'name': 'boundaryLayerConductance'},
   {'interface': ISequence, 'name': 'soilWater'},
   {'interface': IBool, 'name': 'doInitialisationStuff'},
   {'interface': IFloat, 'name': 'maxTempYesterday'},
   {'interface': IFloat, 'name': 'minTempYesterday'}],
                             elt_factory={2: ('amei.dssat_.soiltemp', 'SoilTemperature')},
                             elt_connections={  140725873647984: (2, 0, '__out__', 0),
   140725873648016: (2, 1, '__out__', 1),
   140725873648048: (2, 2, '__out__', 2),
   140725873648080: (2, 3, '__out__', 3),
   140725873648112: (2, 4, '__out__', 4),
   140725873648144: (2, 5, '__out__', 5),
   140725873648176: (2, 6, '__out__', 6),
   140725873648208: (2, 7, '__out__', 7),
   140725873648240: (2, 8, '__out__', 8),
   140725873648272: (2, 9, '__out__', 9),
   140725873648304: (2, 10, '__out__', 10),
   140725873648336: (2, 11, '__out__', 11),
   140725873648368: (2, 12, '__out__', 12),
   140725873648400: (2, 13, '__out__', 13),
   140725873648432: (2, 14, '__out__', 14),
   140725873648464: (2, 15, '__out__', 15),
   140725873648496: ('__in__', 0, 2, 24),
   140725873648528: ('__in__', 1, 2, 53),
   140725873648560: ('__in__', 2, 2, 1),
   140725873648592: ('__in__', 3, 2, 35),
   140725873648624: ('__in__', 4, 2, 56),
   140725873648656: ('__in__', 5, 2, 47),
   140725873648688: ('__in__', 6, 2, 74),
   140725873648720: ('__in__', 7, 2, 64),
   140725873648752: ('__in__', 8, 2, 37),
   140725873648784: ('__in__', 9, 2, 54),
   140725873648816: ('__in__', 10, 2, 71),
   140725873648848: ('__in__', 11, 2, 8),
   140725873648880: ('__in__', 12, 2, 66),
   140725873648912: ('__in__', 13, 2, 28),
   140725873648944: ('__in__', 14, 2, 10),
   140725873648976: ('__in__', 15, 2, 0),
   140725873649008: ('__in__', 16, 2, 17),
   140725873649040: ('__in__', 17, 2, 30),
   140725873649072: ('__in__', 18, 2, 75),
   140725873649104: ('__in__', 19, 2, 13),
   140725873649136: ('__in__', 20, 2, 67),
   140725873649168: ('__in__', 21, 2, 43),
   140725873649200: ('__in__', 22, 2, 61),
   140725873649232: ('__in__', 23, 2, 77),
   140725873649264: ('__in__', 24, 2, 50),
   140725873649296: ('__in__', 25, 2, 6),
   140725873649328: ('__in__', 26, 2, 15),
   140725873649360: ('__in__', 27, 2, 39),
   140725873649392: ('__in__', 28, 2, 76),
   140725873649424: ('__in__', 29, 2, 55),
   140725873649456: ('__in__', 30, 2, 36),
   140725873649488: ('__in__', 31, 2, 60),
   140725873649520: ('__in__', 32, 2, 80),
   140725873649552: ('__in__', 33, 2, 20),
   140725873649584: ('__in__', 34, 2, 58),
   140725873649616: ('__in__', 35, 2, 2),
   140725873649648: ('__in__', 36, 2, 72),
   140725873649680: ('__in__', 37, 2, 65),
   140725873649712: ('__in__', 38, 2, 7),
   140725873649744: ('__in__', 39, 2, 4),
   140725873649776: ('__in__', 40, 2, 27),
   140725873649808: ('__in__', 41, 2, 62),
   140725873649840: ('__in__', 42, 2, 32),
   140725873649872: ('__in__', 43, 2, 81),
   140725873649904: ('__in__', 44, 2, 70),
   140725873649936: ('__in__', 45, 2, 12),
   140725873649968: ('__in__', 46, 2, 41),
   140725873650000: ('__in__', 47, 2, 68),
   140725873650032: ('__in__', 48, 2, 11),
   140725873650064: ('__in__', 49, 2, 73),
   140725873650096: ('__in__', 50, 2, 52),
   140725873650128: ('__in__', 51, 2, 33),
   140725873650160: ('__in__', 52, 2, 48),
   140725873650192: ('__in__', 53, 2, 44),
   140725873650224: ('__in__', 54, 2, 63),
   140725873650256: ('__in__', 55, 2, 23),
   140725873650288: ('__in__', 56, 2, 59),
   140725873650320: ('__in__', 57, 2, 31),
   140725873650352: ('__in__', 58, 2, 79),
   140725873650384: ('__in__', 59, 2, 46),
   140725873650416: ('__in__', 60, 2, 16),
   140725873650448: ('__in__', 61, 2, 42),
   140725873650480: ('__in__', 62, 2, 9),
   140725873650512: ('__in__', 63, 2, 21),
   140725873650544: ('__in__', 64, 2, 26),
   140725873650576: ('__in__', 65, 2, 34),
   140725873650608: ('__in__', 66, 2, 78),
   140725873650640: ('__in__', 67, 2, 19),
   140725873650672: ('__in__', 68, 2, 22),
   140725873650704: ('__in__', 69, 2, 3),
   140725873650736: ('__in__', 70, 2, 49),
   140725873650768: ('__in__', 71, 2, 38),
   140725873650800: ('__in__', 72, 2, 29),
   140725873650832: ('__in__', 73, 2, 14),
   140725873650864: ('__in__', 74, 2, 25),
   140725873650896: ('__in__', 75, 2, 5),
   140725873650928: ('__in__', 76, 2, 45),
   140725873650960: ('__in__', 77, 2, 69),
   140725873650992: ('__in__', 78, 2, 51),
   140725873651024: ('__in__', 79, 2, 18),
   140725873651056: ('__in__', 80, 2, 82),
   140725873651088: ('__in__', 81, 2, 57),
   140725873651120: ('__in__', 82, 2, 40)},
                             elt_data={  2: {  'block': False,
         'caption': 'SoilTemperature',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 0,
         'posy': 250.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   '__in__': {  'block': False,
                'caption': 'In',
                'delay': 0,
                'hide': True,
                'id': 0,
                'lazy': True,
                'port_hide_changed': set(),
                'posx': 250.0,
                'posy': 0,
                'priority': 0,
                'use_user_color': True,
                'user_application': None,
                'user_color': None},
   '__out__': {  'block': False,
                 'caption': 'Out',
                 'delay': 0,
                 'hide': True,
                 'id': 1,
                 'lazy': True,
                 'port_hide_changed': set(),
                 'posx': 250.0,
                 'posy': 500,
                 'priority': 0,
                 'use_user_color': True,
                 'user_application': None,
                 'user_color': None}},
                             elt_value={2: [], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [0, 250.0], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




