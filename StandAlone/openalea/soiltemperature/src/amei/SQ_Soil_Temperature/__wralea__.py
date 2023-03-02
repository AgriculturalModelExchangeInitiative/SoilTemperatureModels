
# This file has been generated at Thu Mar  2 16:38:11 2023

from openalea.core import *


__name__ = 'amei.crop2ml.sq_soil_temperature.soiltemperature'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['SoilTemperature']


__all__ = ['calculatesoiltemperature_model_calculatesoiltemperature', 'calculatehourlysoiltemperature_model_calculatehourlysoiltemperature', 'SoilTemperature']



calculatesoiltemperature_model_calculatesoiltemperature = Factory(name='CalculateSoilTemperature',
                authors='AMEI Consortium (wralea authors)',
                description='Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate.',
                category='Unclassified',
                nodemodule='calculatesoiltemperature',
                nodeclass='model_calculatesoiltemperature',
                inputs=[{'name': 'deepLayerT', 'interface': IFloat(min=-30, max=80, step=1.000000), 'value': 20}, {'name': 'lambda_', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 2.454}, {'name': 'heatFlux', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 50}, {'name': 'meanTAir', 'interface': IFloat(min=-30, max=80, step=1.000000), 'value': 22}, {'name': 'minTAir', 'interface': IFloat(min=-30, max=80, step=1.000000), 'value': 20}, {'name': 'deepLayerT_t1', 'interface': IFloat(min=-30, max=80, step=1.000000), 'value': 20}, {'name': 'maxTAir', 'interface': IFloat(min=-30, max=80, step=1.000000), 'value': 25}],
                outputs=[{'name': 'deepLayerT_t1', 'interface': IFloat(min=-30, max=80, step=1.000000)}, {'name': 'maxTSoil', 'interface': IFloat(min=-30, max=80, step=1.000000)}, {'name': 'minTSoil', 'interface': IFloat(min=-30, max=80, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




calculatehourlysoiltemperature_model_calculatehourlysoiltemperature = Factory(name='CalculateHourlySoilTemperature',
                authors='AMEI Consortium (wralea authors)',
                description='Calculate Soil temperature on a hourly basis.Parton, W.J. and Logan, J.A., 1981. A model for diurnal variation in soil and air temperature. Agric. Meteorol., 23: 205-216',
                category='Unclassified',
                nodemodule='calculatehourlysoiltemperature',
                nodeclass='model_calculatehourlysoiltemperature',
                inputs=[{'name': 'c', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 0.49}, {'name': 'dayLength', 'interface': IFloat(min=0, max=24, step=1.000000), 'value': 12}, {'name': 'maxTSoil', 'interface': IFloat(min=-30, max=80, step=1.000000), 'value': 20}, {'name': 'b', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 1.81}, {'name': 'a', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 0.5}, {'name': 'minTSoil', 'interface': IFloat(min=-30, max=80, step=1.000000), 'value': 20}],
                outputs=[{'name': 'hourlySoilT', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




SoilTemperature = CompositeNodeFactory(name='SoilTemperature',
                             description=('\n'
 '\n'
 '    SoilTemperature model\n'
 '    -Version: 001  -Time step: 1\n'
 '    Authors: loic.manceau@inra.fr\n'
 "    Reference: ('http://biomamodelling.org',)\n"
 '    Institution: INRA\n'
 '    ExtendedDescription: Composite Class for soil temperature\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {  'interface': IFloat(min=-30, max=80, step=1.000000),
      'name': 'deepLayerT',
      'value': 20},
   {  'interface': IFloat(min=0, max=10, step=1.000000),
      'name': 'lambda_',
      'value': 2.454},
   {  'interface': IFloat(min=0, max=100, step=1.000000),
      'name': 'heatFlux',
      'value': 50},
   {  'interface': IFloat(min=-30, max=80, step=1.000000),
      'name': 'meanTAir',
      'value': 22},
   {  'interface': IFloat(min=-30, max=80, step=1.000000),
      'name': 'minTAir',
      'value': 20},
   {  'interface': IFloat(min=-30, max=80, step=1.000000),
      'name': 'maxTAir',
      'value': 25},
   {  'interface': IFloat(min=0, max=10, step=1.000000),
      'name': 'a',
      'value': 0.5},
   {  'interface': IFloat(min=0, max=10, step=1.000000),
      'name': 'b',
      'value': 1.81},
   {  'interface': IFloat(min=0, max=10, step=1.000000),
      'name': 'c',
      'value': 0.49},
   {  'interface': IFloat(min=0, max=24, step=1.000000),
      'name': 'dayLength',
      'value': 12}],
                             outputs=[  {  'interface': IFloat(min=-30, max=80, step=1.000000),
      'name': 'deepLayerT_t1'},
   {'interface': IFloat(min=-30, max=80, step=1.000000), 'name': 'maxTSoil'},
   {'interface': IFloat(min=-30, max=80, step=1.000000), 'name': 'minTSoil'},
   {'interface': ISequence, 'name': 'hourlySoilT'}],
                             elt_factory={  2: (  'amei.crop2ml.sq_soil_temperature.soiltemperature',
         'CalculateSoilTemperature'),
   3: (  'amei.crop2ml.sq_soil_temperature.soiltemperature',
         'CalculateHourlySoilTemperature')},
                             elt_connections={  4550938944: (2, 0, '__out__', 0),
   4550938976: (2, 1, '__out__', 1),
   4550939008: (2, 2, '__out__', 2),
   4550939040: (3, 0, '__out__', 3),
   4550939072: ('__in__', 0, 2, 0),
   4550939104: ('__in__', 1, 2, 1),
   4550939136: ('__in__', 2, 2, 2),
   4550939168: ('__in__', 3, 2, 3),
   4550939200: ('__in__', 4, 2, 4),
   4550939232: ('__in__', 5, 2, 6),
   4550939264: ('__in__', 6, 3, 4),
   4550939296: ('__in__', 7, 3, 3),
   4550939328: ('__in__', 8, 3, 0),
   4550939360: ('__in__', 9, 3, 1),
   4550939392: (2, 1, 3, 2),
   4550939424: (2, 2, 3, 5)},
                             elt_data={  2: {  'block': False,
         'caption': 'CalculateSoilTemperature',
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
         'caption': 'CalculateHourlySoilTemperature',
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
                             elt_value={2: [(5, '20')], 3: [], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [-125, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   3: {'position': [125.0, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




