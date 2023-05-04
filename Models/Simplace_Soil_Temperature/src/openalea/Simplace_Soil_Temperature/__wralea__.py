
# This file has been generated at Thu May  4 16:46:46 2023

from openalea.core import *


__name__ = 'amei.soiltemperature.soiltemperature'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['SoilTemperature']


__all__ = ['snowcovercalculator_model_snowcovercalculator', 'stmpsimcalculator_model_stmpsimcalculator', 'SoilTemperature']



snowcovercalculator_model_snowcovercalculator = Factory(name='SnowCoverCalculator',
                authors='AMEI Consortium (wralea authors)',
                description='as given in the documentation',
                category='Unclassified',
                nodemodule='snowcovercalculator',
                nodeclass='model_snowcovercalculator',
                inputs=[{'name': 'cCarbonContent', 'interface': IFloat(min=0, max=20, step=1.000000), 'value': 0.5}, {'name': 'iTempMax', 'interface': IFloat(min=-40, max=50, step=1.000000), 'value': 0}, {'name': 'iTempMin', 'interface': IFloat(min=-40, max=50, step=1.000000), 'value': 0}, {'name': 'iRadiation', 'interface': IFloat(min=0, max=2000, step=1.000000), 'value': 0}, {'name': 'iRAIN', 'interface': IFloat(min=0, max=60, step=1.000000), 'value': 0}, {'name': 'iCropResidues', 'interface': IFloat(min=0, max=20000, step=1.000000), 'value': 0}, {'name': 'iPotentialSoilEvaporation', 'interface': IFloat(min=0, max=12, step=1.000000), 'value': 0}, {'name': 'iLeafAreaIndex', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 0}, {'name': 'iSoilTempArray', 'interface': ISequence, 'value': 0}, {'name': 'Albedo', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0}, {'name': 'SnowWaterContent', 'interface': IFloat(min=0, max=1500, step=1.000000), 'value': 0.0}, {'name': 'SoilSurfaceTemperature', 'interface': IFloat(min=-40, max=70, step=1.000000), 'value': 0.0}, {'name': 'AgeOfSnow', 'interface': IInt(min=0, max=16777216, step=1), 'value': 0}],
                outputs=[{'name': 'SnowWaterContent', 'interface': IFloat(min=0, max=1500, step=1.000000)}, {'name': 'SoilSurfaceTemperature', 'interface': IFloat(min=-40, max=70, step=1.000000)}, {'name': 'AgeOfSnow', 'interface': IInt(min=0, max=16777216, step=1)}, {'name': 'SnowIsolationIndex', 'interface': IFloat(min=0, max=1, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




stmpsimcalculator_model_stmpsimcalculator = Factory(name='STMPsimCalculator',
                authors='AMEI Consortium (wralea authors)',
                description='as given in the documentation',
                category='Unclassified',
                nodemodule='stmpsimcalculator',
                nodeclass='model_stmpsimcalculator',
                inputs=[{'name': 'cSoilLayerDepth', 'interface': ISequence, 'value': 0}, {'name': 'cFirstDayMeanTemp', 'interface': IFloat(min=-40, max=50, step=1.000000), 'value': 0}, {'name': 'cAVT', 'interface': IFloat(min=-10, max=20, step=1.000000), 'value': 0}, {'name': 'cABD', 'interface': IFloat(min=1, max=4, step=1.000000), 'value': 2.0}, {'name': 'cDampingDepth', 'interface': IFloat(min=1, max=20, step=1.000000), 'value': 6.0}, {'name': 'iSoilWaterContent', 'interface': IFloat(min=1, max=20, step=1.000000), 'value': 5.0}, {'name': 'iSoilSurfaceTemperature', 'interface': IFloat(min=1, max=20, step=1.000000), 'value': 0}, {'name': 'SoilTempArray', 'interface': ISequence, 'value': 0}, {'name': 'rSoilTempArrayRate', 'interface': ISequence, 'value': 0}, {'name': 'pSoilLayerDepth', 'interface': ISequence, 'value': 0}],
                outputs=[{'name': 'SoilTempArray', 'interface': ISequence}, {'name': 'rSoilTempArrayRate', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




SoilTemperature = CompositeNodeFactory(name='SoilTemperature',
                             description=('\n'
 '\n'
 '    SoilTemperature model\n'
 '    -Version: 001  -Time step: 1\n'
 '    Authors: Gunther Krauss\n'
 "    Reference: ('http://www.simplace.net/doc/simplace_modules/',)\n"
 '    Institution: INRES Pflanzenbau, Uni Bonn\n'
 '    ExtendedDescription: as given in the documentation\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {  'interface': IFloat(min=0, max=20, step=1.000000),
      'name': 'cCarbonContent',
      'value': 0.5},
   {'interface': IFloat(min=-40, max=50, step=1.000000), 'name': 'iTempMax'},
   {'interface': IFloat(min=-40, max=50, step=1.000000), 'name': 'iTempMin'},
   {'interface': IFloat(min=0, max=2000, step=1.000000), 'name': 'iRadiation'},
   {'interface': IFloat(min=0, max=60, step=1.000000), 'name': 'iRAIN'},
   {  'interface': IFloat(min=0, max=20000, step=1.000000),
      'name': 'iCropResidues'},
   {  'interface': IFloat(min=0, max=12, step=1.000000),
      'name': 'iPotentialSoilEvaporation'},
   {  'interface': IFloat(min=0, max=10, step=1.000000),
      'name': 'iLeafAreaIndex'},
   {'interface': ISequence, 'name': 'iSoilTempArray'},
   {'interface': ISequence, 'name': 'cSoilLayerDepth'},
   {  'interface': IFloat(min=-40, max=50, step=1.000000),
      'name': 'cFirstDayMeanTemp'},
   {'interface': IFloat(min=-10, max=20, step=1.000000), 'name': 'cAVT'},
   {  'interface': IFloat(min=1, max=4, step=1.000000),
      'name': 'cABD',
      'value': 2.0},
   {  'interface': IFloat(min=1, max=20, step=1.000000),
      'name': 'cDampingDepth',
      'value': 6.0},
   {  'interface': IFloat(min=1, max=20, step=1.000000),
      'name': 'iSoilWaterContent',
      'value': 5.0},
   {'interface': IFloat(min=0, max=1, step=1.000000), 'name': 'Albedo'},
   {  'interface': IFloat(min=0, max=1500, step=1.000000),
      'name': 'SnowWaterContent'},
   {  'interface': IFloat(min=-40, max=70, step=1.000000),
      'name': 'SoilSurfaceTemperature'},
   {'interface': IInt(min=0, max=16777216, step=1), 'name': 'AgeOfSnow'},
   {'interface': ISequence, 'name': 'rSoilTempArrayRate'},
   {'interface': ISequence, 'name': 'pSoilLayerDepth'}],
                             outputs=[  {  'interface': IFloat(min=-40, max=70, step=1.000000),
      'name': 'SoilSurfaceTemperature'},
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'SnowIsolationIndex'},
   {  'interface': IFloat(min=0, max=1500, step=1.000000),
      'name': 'SnowWaterContent'},
   {'interface': ISequence, 'name': 'SoilTempArray'},
   {'interface': IInt(min=0, max=16777216, step=1), 'name': 'AgeOfSnow'},
   {'interface': ISequence, 'name': 'rSoilTempArrayRate'}],
                             elt_factory={  2: ('amei.soiltemperature.soiltemperature', 'SnowCoverCalculator'),
   3: ('amei.soiltemperature.soiltemperature', 'STMPsimCalculator')},
                             elt_connections={  140722522333552: (2, 1, '__out__', 0),
   140722522333584: (2, 3, '__out__', 1),
   140722522333616: (2, 0, '__out__', 2),
   140722522333648: (3, 0, '__out__', 3),
   140722522333680: (2, 2, '__out__', 4),
   140722522333712: (3, 1, '__out__', 5),
   140722522333744: ('__in__', 0, 2, 0),
   140722522333776: ('__in__', 1, 2, 1),
   140722522333808: ('__in__', 2, 2, 2),
   140722522333840: ('__in__', 3, 2, 3),
   140722522333872: ('__in__', 4, 2, 4),
   140722522333904: ('__in__', 5, 2, 5),
   140722522333936: ('__in__', 6, 2, 6),
   140722522333968: ('__in__', 7, 2, 7),
   140722522334000: ('__in__', 8, 2, 8),
   140722522334032: ('__in__', 9, 3, 0),
   140722522334064: ('__in__', 10, 3, 1),
   140722522334096: ('__in__', 11, 3, 2),
   140722522334128: ('__in__', 12, 3, 3),
   140722522334160: ('__in__', 13, 3, 4),
   140722522334192: ('__in__', 14, 3, 5),
   140722522334224: ('__in__', 15, 2, 9),
   140722522334256: ('__in__', 16, 2, 10),
   140722522334288: ('__in__', 17, 2, 11),
   140722522334320: ('__in__', 18, 2, 12),
   140722522334352: ('__in__', 19, 3, 8),
   140722522334384: ('__in__', 20, 3, 9),
   140722522334416: (2, 1, 3, 6)},
                             elt_data={  2: {  'block': False,
         'caption': 'SnowCoverCalculator',
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
         'caption': 'STMPsimCalculator',
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
                             elt_value={2: [], 3: [(7, '0')], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [-125, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   3: {'position': [125.0, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




