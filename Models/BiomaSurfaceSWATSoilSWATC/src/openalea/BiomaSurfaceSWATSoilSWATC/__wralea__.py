
# This file has been generated at Thu Nov 30 12:33:26 2023

from openalea.core import *


__name__ = 'amei.crop2ml.biomasurfaceswatsoilswatc'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['SurfaceSWATSoilSWATC']


__all__ = ['surfacetemperatureswat_model_surfacetemperatureswat', 'soiltemperatureswat_model_soiltemperatureswat', 'SurfaceSWATSoilSWATC']



surfacetemperatureswat_model_surfacetemperatureswat = Factory(name='SurfaceTemperatureSWAT',
                authors='AMEI Consortium (wralea authors)',
                description='Strategy for the calculation of surface soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf',
                category='Unclassified',
                nodemodule='surfacetemperatureswat',
                nodeclass='model_surfacetemperatureswat',
                inputs=[{'name': 'GlobalSolarRadiation', 'interface': IFloat(min=0, max=50, step=1.000000), 'value': 15}, {'name': 'SoilTemperatureByLayers', 'interface': ISequence, 'value': 15}, {'name': 'AirTemperatureMaximum', 'interface': IFloat(min=-40, max=60, step=1.000000), 'value': 15}, {'name': 'AirTemperatureMinimum', 'interface': IFloat(min=-60, max=50, step=1.000000), 'value': 5}, {'name': 'Albedo', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0.2}, {'name': 'AboveGroundBiomass', 'interface': IFloat(min=0, max=60, step=1.000000), 'value': 3}, {'name': 'WaterEquivalentOfSnowPack', 'interface': IFloat(min=0, max=1000, step=1.000000), 'value': 10}],
                outputs=[{'name': 'SurfaceSoilTemperature', 'interface': IFloat(min=-60, max=60, step=1.000000)}],
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




SurfaceSWATSoilSWATC = CompositeNodeFactory(name='SurfaceSWATSoilSWATC',
                             description=('\n'
 '\n'
 '    SurfaceSWATSoilSWATC model\n'
 '    -Version: 001  -Time step: 1\n'
 '    Authors: simone.bregaglio@unimi.it\n'
 '    Reference: '
 "('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)\n"
 '    Institution: Universiy Of Milan\n'
 '    ExtendedDescription: Composite strategy for the calculation of surface '
 'and soil temperature with SWAT method. Neitsch,S.L., Arnold, J.G., Kiniry, '
 'J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical '
 'documentation. Version 2000. '
 'http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf.  Composite '
 'strategy. See also references of the associated strategies.\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {  'interface': IFloat(min=-40, max=60, step=1.000000),
      'name': 'AirTemperatureMaximum',
      'value': 15},
   {  'interface': IFloat(min=-60, max=50, step=1.000000),
      'name': 'AirTemperatureMinimum',
      'value': 5},
   {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'GlobalSolarRadiation',
      'value': 15},
   {  'interface': IFloat(min=0, max=60, step=1.000000),
      'name': 'AboveGroundBiomass',
      'value': 3},
   {  'interface': IFloat(min=0, max=1000, step=1.000000),
      'name': 'WaterEquivalentOfSnowPack',
      'value': 10},
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'Albedo',
      'value': 0.2},
   {'interface': ISequence, 'name': 'BulkDensity', 'value': 1.3},
   {  'interface': IFloat(min=-40, max=50, step=1.000000),
      'name': 'AirTemperatureAnnualAverage',
      'value': 15},
   {'interface': ISequence, 'name': 'VolumetricWaterContent', 'value': 0.25},
   {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'SoilProfileDepth',
      'value': 3},
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'LagCoefficient',
      'value': 0.8},
   {'interface': ISequence, 'name': 'LayerThickness', 'value': 0.05}],
                             outputs=[  {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'SurfaceSoilTemperature'},
   {'interface': ISequence, 'name': 'SoilTemperatureByLayers'}],
                             elt_factory={  2: ('amei.crop2ml.biomasurfaceswatsoilswatc', 'SurfaceTemperatureSWAT'),
   3: ('amei.crop2ml.biomasurfaceswatsoilswatc', 'SoilTemperatureSWAT')},
                             elt_connections={  140723302080880: (2, 0, '__out__', 0),
   140723302080912: (3, 0, '__out__', 1),
   140723302080944: ('__in__', 0, 2, 2),
   140723302080976: ('__in__', 1, 2, 3),
   140723302081008: ('__in__', 2, 2, 0),
   140723302081040: ('__in__', 3, 2, 5),
   140723302081072: ('__in__', 4, 2, 6),
   140723302081104: ('__in__', 5, 2, 4),
   140723302081136: ('__in__', 6, 3, 6),
   140723302081168: ('__in__', 7, 3, 5),
   140723302081200: ('__in__', 8, 3, 0),
   140723302081232: ('__in__', 9, 3, 7),
   140723302081264: ('__in__', 10, 3, 3),
   140723302081296: ('__in__', 11, 3, 2),
   140723302081328: (2, 0, 3, 1)},
                             elt_data={  2: {  'block': False,
         'caption': 'SurfaceTemperatureSWAT',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': -125,
         'posy': 166.66666666666666,
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
         'posx': 125.0,
         'posy': 166.66666666666666,
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
                             elt_value={2: [(1, '15')], 3: [(4, '15')], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [-125, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   3: {'position': [125.0, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




