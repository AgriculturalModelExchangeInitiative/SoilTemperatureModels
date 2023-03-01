
# This file has been generated at Wed Mar  1 20:15:49 2023

from openalea.core import *


__name__ = 'SurfacePartonSoilSWATC'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'OpenAlea Consortium'
__institutes__ = 'INRA/CIRAD'
__description__ = 'CropML Model library.'
__url__ = 'http://pycropml.rtfd.org'
__icon__ = ''
__alias__ = []


__all__ = ['surfacetemperatureparton_model_surfacetemperatureparton', 'soiltemperatureswat_model_soiltemperatureswat', '_2696027161480']



surfacetemperatureparton_model_surfacetemperatureparton = Factory(name='SurfaceTemperatureParton',
                authors='OpenAlea Consortium (wralea authors)',
                description="Strategy for the calculation of soil surface temperature with Parton's method. Reference: Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101.",
                category='Unclassified',
                nodemodule='surfacetemperatureparton',
                nodeclass='model_surfacetemperatureparton',
                inputs=[{'name': 'SurfaceTemperatureMaximum', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 25}, {'name': 'GlobalSolarRadiation', 'interface': IFloat(min=0, max=50, step=1.000000), 'value': 15}, {'name': 'SurfaceTemperatureMinimum', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 10}, {'name': 'AboveGroundBiomass', 'interface': IFloat(min=0, max=60, step=1.000000), 'value': 3}, {'name': 'AirTemperatureMinimum', 'interface': IFloat(min=-60, max=50, step=1.000000), 'value': 5}, {'name': 'AirTemperatureMaximum', 'interface': IFloat(min=-40, max=60, step=1.000000), 'value': 15}, {'name': 'DayLength', 'interface': IFloat(min=0, max=24, step=1.000000), 'value': 10}],
                outputs=[{'name': 'SurfaceTemperatureMaximum', 'interface': IFloat(min=-60, max=60, step=1.000000)}, {'name': 'SurfaceTemperatureMinimum', 'interface': IFloat(min=-60, max=60, step=1.000000)}, {'name': 'SurfaceSoilTemperature', 'interface': IFloat(min=-60, max=60, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




soiltemperatureswat_model_soiltemperatureswat = Factory(name='SoilTemperatureSWAT',
                authors='OpenAlea Consortium (wralea authors)',
                description='Strategy for the calculation of soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf',
                category='Unclassified',
                nodemodule='soiltemperatureswat',
                nodeclass='model_soiltemperatureswat',
                inputs=[{'name': 'SoilTemperatureByLayers', 'interface': ISequence, 'value': 15}, {'name': 'SurfaceSoilTemperature', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 25}, {'name': 'AirTemperatureAnnualAverage', 'interface': IFloat(min=-40, max=50, step=1.000000), 'value': 15}, {'name': 'SoilProfileDepth', 'interface': IFloat(min=0, max=50, step=1.000000), 'value': 3}, {'name': 'LagCoefficient', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0.8}, {'name': 'BulkDensity', 'interface': ISequence, 'value': 1.3}, {'name': 'VolumetricWaterContent', 'interface': ISequence, 'value': 0.25}, {'name': 'LayerThickness', 'interface': ISequence, 'value': 0.05}],
                outputs=[{'name': 'SoilTemperatureByLayers', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




_2696027161480 = CompositeNodeFactory(name='SurfacePartonSoilSWATC_wf',
                             description=('\n'
 '\n'
 '    SurfacePartonSoilSWATC model\n'
 '    -Version: 001  -Time step: 1\n'
 '    Authors: simone.bregaglio@unimi.it\n'
 '    Reference: '
 "('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)\n"
 '    Institution: Universiy Of Milan\n'
 '    ExtendedDescription: Composite strategy for the calculation of surface '
 "temperature with Parton's method and soil temperature with SWAT method. "
 'Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. '
 'Soil Science 138:93-101. and Neitsch,S.L., Arnold, J.G., Kiniry, J.R., '
 'Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical '
 'documentation. Version 2000. '
 'http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf.  Composite '
 'strategy. See also references of the associated strategies.\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'GlobalSolarRadiation',
      'value': 15},
   {  'interface': IFloat(min=0, max=60, step=1.000000),
      'name': 'AboveGroundBiomass',
      'value': 3},
   {  'interface': IFloat(min=-40, max=60, step=1.000000),
      'name': 'AirTemperatureMaximum',
      'value': 15},
   {  'interface': IFloat(min=-60, max=50, step=1.000000),
      'name': 'AirTemperatureMinimum',
      'value': 5},
   {  'interface': IFloat(min=0, max=24, step=1.000000),
      'name': 'DayLength',
      'value': 10},
   {  'interface': IFloat(min=-40, max=50, step=1.000000),
      'name': 'AirTemperatureAnnualAverage',
      'value': 15},
   {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'SoilProfileDepth',
      'value': 3},
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'LagCoefficient',
      'value': 0.8},
   {'interface': ISequence, 'name': 'BulkDensity', 'value': 1.3},
   {'interface': ISequence, 'name': 'VolumetricWaterContent', 'value': 0.25},
   {'interface': ISequence, 'name': 'LayerThickness', 'value': 0.05}],
                             outputs=[  {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'SurfaceTemperatureMaximum'},
   {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'SurfaceTemperatureMinimum'},
   {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'SurfaceSoilTemperature'},
   {'interface': ISequence, 'name': 'SoilTemperatureByLayers'}],
                             elt_factory={  2: ('SurfacePartonSoilSWATC', 'SurfaceTemperatureParton'),
   3: ('SurfacePartonSoilSWATC', 'SoilTemperatureSWAT')},
                             elt_connections={  140730998825328: (2, 0, '__out__', 0),
   140730998825360: (2, 1, '__out__', 1),
   140730998825392: (2, 2, '__out__', 2),
   140730998825424: (3, 0, '__out__', 3),
   140730998825456: ('__in__', 0, 2, 1),
   140730998825488: ('__in__', 1, 2, 3),
   140730998825520: ('__in__', 2, 2, 5),
   140730998825552: ('__in__', 3, 2, 4),
   140730998825584: ('__in__', 4, 2, 6),
   140730998825616: ('__in__', 5, 3, 2),
   140730998825648: ('__in__', 6, 3, 3),
   140730998825680: ('__in__', 7, 3, 4),
   140730998825712: ('__in__', 8, 3, 5),
   140730998825744: ('__in__', 9, 3, 6),
   140730998825776: ('__in__', 10, 3, 7),
   140730998825808: (2, 2, 3, 1)},
                             elt_data={  2: {  'block': False,
         'caption': 'SurfaceTemperatureParton',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 0,
         'posy': 0,
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
         'posx': 0,
         'posy': 0,
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
                'posx': 0,
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
                 'posx': 0,
                 'posy': 0,
                 'priority': 0,
                 'use_user_color': True,
                 'user_application': None,
                 'user_color': None}},
                             elt_value={2: [(0, '25'), (2, '10')], 3: [(0, '15')], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   3: {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [0, 0], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




