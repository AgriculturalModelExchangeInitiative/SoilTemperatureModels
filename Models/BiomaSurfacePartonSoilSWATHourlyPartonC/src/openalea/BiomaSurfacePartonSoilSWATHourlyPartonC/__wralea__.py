
# This file has been generated at Thu Nov 30 11:10:10 2023

from openalea.core import *


__name__ = 'amei.crop2ml.biomasurfacepartonsoilswathourlypartonc'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['SurfacePartonSoilSWATHourlyPartonC']


__all__ = ['surfacetemperatureparton_model_surfacetemperatureparton', 'soiltemperatureswat_model_soiltemperatureswat', 'volumetricheatcapacitykluitenberg_model_volumetricheatcapacitykluitenberg', 'thermalconductivitysimulat_model_thermalconductivitysimulat', 'thermaldiffu_model_thermaldiffu', 'rangeofsoiltemperaturesdaycent_model_rangeofsoiltemperaturesdaycent', 'hourlysoiltemperaturespartonlogan_model_hourlysoiltemperaturespartonlogan', 'SurfacePartonSoilSWATHourlyPartonC']



surfacetemperatureparton_model_surfacetemperatureparton = Factory(name='SurfaceTemperatureParton',
                authors='AMEI Consortium (wralea authors)',
                description="Strategy for the calculation of soil surface temperature with Parton's method. Reference: Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101.",
                category='Unclassified',
                nodemodule='surfacetemperatureparton',
                nodeclass='model_surfacetemperatureparton',
                inputs=[{'name': 'GlobalSolarRadiation', 'interface': IFloat(min=0, max=50, step=1.000000), 'value': 15}, {'name': 'DayLength', 'interface': IFloat(min=0, max=24, step=1.000000), 'value': 10}, {'name': 'AboveGroundBiomass', 'interface': IFloat(min=0, max=60, step=1.000000), 'value': 3}, {'name': 'AirTemperatureMinimum', 'interface': IFloat(min=-60, max=50, step=1.000000), 'value': 5}, {'name': 'AirTemperatureMaximum', 'interface': IFloat(min=-40, max=60, step=1.000000), 'value': 15}],
                outputs=[{'name': 'SurfaceSoilTemperature', 'interface': IFloat(min=-60, max=60, step=1.000000)}, {'name': 'SurfaceTemperatureMinimum', 'interface': IFloat(min=-60, max=60, step=1.000000)}, {'name': 'SurfaceTemperatureMaximum', 'interface': IFloat(min=-60, max=60, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




soiltemperatureswat_model_soiltemperatureswat = Factory(name='SoilTemperatureSWAT',
                authors='AMEI Consortium (wralea authors)',
                description='Strategy for the calculation of soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf',
                category='Unclassified',
                nodemodule='soiltemperatureswat',
                nodeclass='model_soiltemperatureswat',
                inputs=[{'name': 'VolumetricWaterContent', 'interface': ISequence, 'value': 0.25}, {'name': 'SurfaceSoilTemperature', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 25}, {'name': 'LayerThickness', 'interface': ISequence, 'value': 0.05}, {'name': 'LagCoefficient', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0.8}, {'name': 'SoilTemperatureByLayers', 'interface': ISequence, 'value': 15}, {'name': 'AirTemperatureAnnualAverage', 'interface': IFloat(min=-40, max=50, step=1.000000), 'value': 15}, {'name': 'BulkDensity', 'interface': ISequence, 'value': 1.3}, {'name': 'SoilProfileDepth', 'interface': IFloat(min=0, max=50, step=1.000000), 'value': 3}],
                outputs=[{'name': 'SoilTemperatureByLayers', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




volumetricheatcapacitykluitenberg_model_volumetricheatcapacitykluitenberg = Factory(name='VolumetricHeatCapacityKluitenberg',
                authors='AMEI Consortium (wralea authors)',
                description='Strategy for the calculation of soil thermal diffusivity. Reference: J.M.H.Hendrickx, H. Xie, B. Borchers, J.B.J. Harrison, 2008. Global Prediction of Thermal Soil Regimes. SPIE Proceedings Volume 6953 Detection and Sensing of Mines, Explosive Objects, and Obscured Targets XIII.',
                category='Unclassified',
                nodemodule='volumetricheatcapacitykluitenberg',
                nodeclass='model_volumetricheatcapacitykluitenberg',
                inputs=[{'name': 'VolumetricWaterContent', 'interface': ISequence, 'value': 0.25}, {'name': 'Sand', 'interface': ISequence, 'value': 30}, {'name': 'BulkDensity', 'interface': ISequence, 'value': 1.3}, {'name': 'OrganicMatter', 'interface': ISequence, 'value': 1.5}, {'name': 'HeatCapacity', 'interface': ISequence, 'value': 20}, {'name': 'Clay', 'interface': ISequence, 'value': 0}, {'name': 'Silt', 'interface': ISequence, 'value': 20}],
                outputs=[{'name': 'HeatCapacity', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




thermalconductivitysimulat_model_thermalconductivitysimulat = Factory(name='ThermalConductivitySIMULAT',
                authors='AMEI Consortium (wralea authors)',
                description='Strategy for the calculation of thermal conductivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series',
                category='Unclassified',
                nodemodule='thermalconductivitysimulat',
                nodeclass='model_thermalconductivitysimulat',
                inputs=[{'name': 'VolumetricWaterContent', 'interface': ISequence, 'value': 0.25}, {'name': 'BulkDensity', 'interface': ISequence, 'value': 1.3}, {'name': 'Clay', 'interface': ISequence, 'value': 0}, {'name': 'ThermalConductivity', 'interface': ISequence, 'value': 0}],
                outputs=[{'name': 'ThermalConductivity', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




thermaldiffu_model_thermaldiffu = Factory(name='ThermalDiffu',
                authors='AMEI Consortium (wralea authors)',
                description='Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series',
                category='Unclassified',
                nodemodule='thermaldiffu',
                nodeclass='model_thermaldiffu',
                inputs=[{'name': 'ThermalDiffusivity', 'interface': ISequence, 'value': 0.0025}, {'name': 'ThermalConductivity', 'interface': ISequence, 'value': 1}, {'name': 'HeatCapacity', 'interface': ISequence, 'value': 20}, {'name': 'layersNumber', 'interface': IInt(min=0, max=300, step=1), 'value': 10}],
                outputs=[{'name': 'ThermalDiffusivity', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




rangeofsoiltemperaturesdaycent_model_rangeofsoiltemperaturesdaycent = Factory(name='RangeOfSoilTemperaturesDAYCENT',
                authors='AMEI Consortium (wralea authors)',
                description='Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code',
                category='Unclassified',
                nodemodule='rangeofsoiltemperaturesdaycent',
                nodeclass='model_rangeofsoiltemperaturesdaycent',
                inputs=[{'name': 'LayerThickness', 'interface': ISequence, 'value': 0.05}, {'name': 'SurfaceTemperatureMinimum', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 10}, {'name': 'ThermalDiffusivity', 'interface': ISequence, 'value': 0.0025}, {'name': 'SoilTemperatureByLayers', 'interface': ISequence, 'value': 15}, {'name': 'SurfaceTemperatureMaximum', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 25}, {'name': 'SoilTemperatureRangeByLayers', 'interface': ISequence, 'value': 0}, {'name': 'SoilTemperatureMinimum', 'interface': ISequence, 'value': 0}, {'name': 'SoilTemperatureMaximum', 'interface': ISequence, 'value': 0}],
                outputs=[{'name': 'SoilTemperatureRangeByLayers', 'interface': ISequence}, {'name': 'SoilTemperatureMinimum', 'interface': ISequence}, {'name': 'SoilTemperatureMaximum', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




hourlysoiltemperaturespartonlogan_model_hourlysoiltemperaturespartonlogan = Factory(name='HourlySoilTemperaturesPartonLogan',
                authors='AMEI Consortium (wralea authors)',
                description='Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.',
                category='Unclassified',
                nodemodule='hourlysoiltemperaturespartonlogan',
                nodeclass='model_hourlysoiltemperaturespartonlogan',
                inputs=[{'name': 'SoilTemperatureByLayersHourly', 'interface': ISequence, 'value': 15}, {'name': 'HourOfSunrise', 'interface': IFloat(min=0, max=24, step=1.000000), 'value': 6}, {'name': 'HourOfSunset', 'interface': IFloat(min=0, max=24, step=1.000000), 'value': 17}, {'name': 'DayLength', 'interface': IFloat(min=0, max=24, step=1.000000), 'value': 10}, {'name': 'SoilTemperatureMinimum', 'interface': ISequence, 'value': 15}, {'name': 'SoilTemperatureMaximum', 'interface': ISequence, 'value': 15}],
                outputs=[{'name': 'SoilTemperatureByLayersHourly', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




SurfacePartonSoilSWATHourlyPartonC = CompositeNodeFactory(name='SurfacePartonSoilSWATHourlyPartonC',
                             description=('\n'
 '\n'
 '    SurfacePartonSoilSWATHourlyPartonC model\n'
 '    -Version: 001  -Time step: 1\n'
 '    Authors: simone.bregaglio@unimi.it\n'
 '    Reference: '
 "('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)\n"
 '    Institution: Universiy Of Milan\n'
 '    ExtendedDescription: Composite strategy for the calculation of surface '
 "temperature with Parton's method and soil temperature with SWAT method. See "
 'also references of the associated strategies.\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {  'interface': IFloat(min=0, max=60, step=1.000000),
      'name': 'AboveGroundBiomass',
      'value': 3},
   {  'interface': IFloat(min=-60, max=50, step=1.000000),
      'name': 'AirTemperatureMinimum',
      'value': 5},
   {  'interface': IFloat(min=0, max=24, step=1.000000),
      'name': 'DayLength',
      'value': 10},
   {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'GlobalSolarRadiation',
      'value': 15},
   {  'interface': IFloat(min=-40, max=60, step=1.000000),
      'name': 'AirTemperatureMaximum',
      'value': 15},
   {'interface': ISequence, 'name': 'VolumetricWaterContent', 'value': 0.25},
   {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'SoilProfileDepth',
      'value': 3},
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'LagCoefficient',
      'value': 0.8},
   {  'interface': IFloat(min=-40, max=50, step=1.000000),
      'name': 'AirTemperatureAnnualAverage',
      'value': 15},
   {'interface': ISequence, 'name': 'LayerThickness', 'value': 0.05},
   {'interface': ISequence, 'name': 'BulkDensity', 'value': 1.3},
   {'interface': ISequence, 'name': 'Sand', 'value': 30},
   {'interface': ISequence, 'name': 'Silt', 'value': 20},
   {'interface': ISequence, 'name': 'Clay'},
   {'interface': ISequence, 'name': 'OrganicMatter', 'value': 1.5},
   {  'interface': IInt(min=0, max=300, step=1),
      'name': 'layersNumber',
      'value': 10},
   {  'interface': IFloat(min=0, max=24, step=1.000000),
      'name': 'HourOfSunset',
      'value': 17},
   {  'interface': IFloat(min=0, max=24, step=1.000000),
      'name': 'HourOfSunrise',
      'value': 6}],
                             outputs=[  {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'SurfaceSoilTemperature'},
   {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'SurfaceTemperatureMinimum'},
   {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'SurfaceTemperatureMaximum'},
   {'interface': ISequence, 'name': 'SoilTemperatureByLayers'},
   {'interface': ISequence, 'name': 'HeatCapacity'},
   {'interface': ISequence, 'name': 'ThermalConductivity'},
   {'interface': ISequence, 'name': 'ThermalDiffusivity'},
   {'interface': ISequence, 'name': 'SoilTemperatureRangeByLayers'},
   {'interface': ISequence, 'name': 'SoilTemperatureMinimum'},
   {'interface': ISequence, 'name': 'SoilTemperatureMaximum'},
   {'interface': ISequence, 'name': 'SoilTemperatureByLayersHourly'}],
                             elt_factory={  2: (  'amei.crop2ml.biomasurfacepartonsoilswathourlypartonc',
         'SurfaceTemperatureParton'),
   3: (  'amei.crop2ml.biomasurfacepartonsoilswathourlypartonc',
         'SoilTemperatureSWAT'),
   4: (  'amei.crop2ml.biomasurfacepartonsoilswathourlypartonc',
         'VolumetricHeatCapacityKluitenberg'),
   5: (  'amei.crop2ml.biomasurfacepartonsoilswathourlypartonc',
         'ThermalConductivitySIMULAT'),
   6: ('amei.crop2ml.biomasurfacepartonsoilswathourlypartonc', 'ThermalDiffu'),
   7: (  'amei.crop2ml.biomasurfacepartonsoilswathourlypartonc',
         'RangeOfSoilTemperaturesDAYCENT'),
   8: (  'amei.crop2ml.biomasurfacepartonsoilswathourlypartonc',
         'HourlySoilTemperaturesPartonLogan')},
                             elt_connections={  140723302080880: (2, 0, '__out__', 0),
   140723302080912: (2, 1, '__out__', 1),
   140723302080944: (2, 2, '__out__', 2),
   140723302080976: (3, 0, '__out__', 3),
   140723302081008: (4, 0, '__out__', 4),
   140723302081040: (5, 0, '__out__', 5),
   140723302081072: (6, 0, '__out__', 6),
   140723302081104: (7, 0, '__out__', 7),
   140723302081136: (7, 1, '__out__', 8),
   140723302081168: (7, 2, '__out__', 9),
   140723302081200: (8, 0, '__out__', 10),
   140723302081232: ('__in__', 0, 2, 2),
   140723302081264: ('__in__', 1, 2, 3),
   140723302081296: ('__in__', 2, 2, 1),
   140723302081328: ('__in__', 3, 2, 0),
   140723302081360: ('__in__', 4, 2, 4),
   140723302081392: ('__in__', 5, 3, 0),
   140723302081424: ('__in__', 6, 3, 7),
   140723302081456: ('__in__', 7, 3, 3),
   140723302081488: ('__in__', 8, 3, 5),
   140723302081520: ('__in__', 9, 3, 2),
   140723302081552: ('__in__', 10, 3, 6),
   140723302081584: ('__in__', 11, 4, 1),
   140723302081616: ('__in__', 5, 4, 0),
   140723302081648: ('__in__', 12, 4, 6),
   140723302081680: ('__in__', 13, 4, 5),
   140723302081712: ('__in__', 10, 4, 2),
   140723302081744: ('__in__', 14, 4, 3),
   140723302081776: ('__in__', 13, 5, 2),
   140723302081808: ('__in__', 5, 5, 0),
   140723302081840: ('__in__', 10, 5, 1),
   140723302081872: ('__in__', 15, 6, 3),
   140723302081904: ('__in__', 9, 7, 0),
   140723302081936: ('__in__', 16, 8, 2),
   140723302081968: ('__in__', 17, 8, 1),
   140723302082000: ('__in__', 2, 8, 3),
   140723302082032: (2, 0, 3, 1),
   140723302082064: (2, 2, 7, 4),
   140723302082096: (2, 1, 7, 1),
   140723302082128: (3, 0, 7, 3),
   140723302082160: (4, 0, 6, 2),
   140723302082192: (5, 0, 6, 1),
   140723302082224: (6, 0, 7, 2),
   140723302082256: (7, 1, 8, 4),
   140723302082288: (7, 2, 8, 5)},
                             elt_data={  2: {  'block': False,
         'caption': 'SurfaceTemperatureParton',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': -68,
         'posy': 100.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   3: {  'block': False,
         'caption': 'SoilTemperatureSWAT',
         'delay': 0,
         'hide': True,
         'id': 3,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': -45.27272727272727,
         'posy': 100.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   4: {  'block': False,
         'caption': 'VolumetricHeatCapacityKluitenberg',
         'delay': 0,
         'hide': True,
         'id': 4,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': -22.545454545454547,
         'posy': 100.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   5: {  'block': False,
         'caption': 'ThermalConductivitySIMULAT',
         'delay': 0,
         'hide': True,
         'id': 5,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 0.18181818181817988,
         'posy': 100.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   6: {  'block': False,
         'caption': 'ThermalDiffu',
         'delay': 0,
         'hide': True,
         'id': 6,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 22.909090909090907,
         'posy': 100.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   7: {  'block': False,
         'caption': 'RangeOfSoilTemperaturesDAYCENT',
         'delay': 0,
         'hide': True,
         'id': 7,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 45.63636363636363,
         'posy': 100.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   8: {  'block': False,
         'caption': 'HourlySoilTemperaturesPartonLogan',
         'delay': 0,
         'hide': True,
         'id': 8,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 68.36363636363636,
         'posy': 100.0,
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
                             elt_value={  2: [],
   3: [(4, '15')],
   4: [(4, '20')],
   5: [(3, '0')],
   6: [(0, '0.0025')],
   7: [(5, '0'), (6, '0'), (7, '0')],
   8: [(0, '15')],
   '__in__': [],
   '__out__': []},
                             elt_ad_hoc={  2: {'position': [-68, 100.0], 'userColor': None, 'useUserColor': True},
   3: {'position': [-45.27272727272727, 100.0], 'userColor': None, 'useUserColor': True},
   4: {'position': [-22.545454545454547, 100.0], 'userColor': None, 'useUserColor': True},
   5: {'position': [0.18181818181817988, 100.0], 'userColor': None, 'useUserColor': True},
   6: {'position': [22.909090909090907, 100.0], 'userColor': None, 'useUserColor': True},
   7: {'position': [45.63636363636363, 100.0], 'userColor': None, 'useUserColor': True},
   8: {'position': [68.36363636363636, 100.0], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




