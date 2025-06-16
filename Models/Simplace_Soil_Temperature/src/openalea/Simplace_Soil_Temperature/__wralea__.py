
# -*- coding: latin-1 -*-
# This file has been generated at Wed Nov  6 14:52:08 2024

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
                inputs=[{'name': 'cCarbonContent', 'interface': IFloat(min=0, max=20, step=1.000000), 'value': 0.5}, {'name': 'cInitialAgeOfSnow', 'interface': IInt(min=0, max=16777216, step=1), 'value': 0}, {'name': 'cInitialSnowWaterContent', 'interface': IFloat(min=0, max=1500, step=1.000000), 'value': 0.0}, {'name': 'Albedo', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0}, {'name': 'pInternalAlbedo', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0}, {'name': 'cSnowIsolationFactorA', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 2.3}, {'name': 'cSnowIsolationFactorB', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0.22}, {'name': 'iTempMax', 'interface': IFloat(min=-40, max=50, step=1.000000), 'value': 0}, {'name': 'iTempMin', 'interface': IFloat(min=-40, max=50, step=1.000000), 'value': 0}, {'name': 'iRadiation', 'interface': IFloat(min=0, max=2000, step=1.000000), 'value': 0}, {'name': 'iRAIN', 'interface': IFloat(min=0, max=60, step=1.000000), 'value': 0.0}, {'name': 'iCropResidues', 'interface': IFloat(min=0, max=20000, step=1.000000), 'value': 0}, {'name': 'iPotentialSoilEvaporation', 'interface': IFloat(min=0, max=12, step=1.000000), 'value': 0.0}, {'name': 'iLeafAreaIndex', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 0}, {'name': 'iSoilTempArray', 'interface': ISequence, 'value': 0}, {'name': 'SnowWaterContent', 'interface': IFloat(min=0, max=1500, step=1.000000), 'value': 0.0}, {'name': 'SoilSurfaceTemperature', 'interface': IFloat(min=-40, max=70, step=1.000000), 'value': 0.0}, {'name': 'AgeOfSnow', 'interface': IInt(min=0, max=16777216, step=1), 'value': 0}],
                outputs=[{'name': 'SnowWaterContent', 'interface': IFloat(min=0, max=1500, step=1.000000)}, {'name': 'SoilSurfaceTemperature', 'interface': IFloat(min=-40, max=70, step=1.000000)}, {'name': 'AgeOfSnow', 'interface': IInt(min=0, max=16777216, step=1)}, {'name': 'rSnowWaterContentRate', 'interface': IFloat(min=-1500, max=1500, step=1.000000)}, {'name': 'rSoilSurfaceTemperatureRate', 'interface': IFloat(min=-40, max=70, step=1.000000)}, {'name': 'rAgeOfSnowRate', 'interface': IInt}, {'name': 'SnowIsolationIndex', 'interface': IFloat(min=0, max=1, step=1.000000)}],
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
   {'interface': IFloat(min=0, max=1, step=1.000000), 'name': 'Albedo'},
   {  'interface': IInt(min=0, max=16777216, step=1),
      'name': 'cInitialAgeOfSnow'},
   {  'interface': IFloat(min=0, max=1500, step=1.000000),
      'name': 'cInitialSnowWaterContent'},
   {  'interface': IFloat(min=0, max=10, step=1.000000),
      'name': 'cSnowIsolationFactorA',
      'value': 2.3},
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'cSnowIsolationFactorB',
      'value': 0.22},
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
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'pInternalAlbedo'},
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
   {  'interface': IFloat(min=-1500, max=1500, step=1.000000),
      'name': 'rSnowWaterContentRate'},
   {  'interface': IFloat(min=-40, max=70, step=1.000000),
      'name': 'rSoilSurfaceTemperatureRate'},
   {'interface': IInt, 'name': 'rAgeOfSnowRate'},
   {'interface': IInt(min=0, max=16777216, step=1), 'name': 'AgeOfSnow'},
   {'interface': ISequence, 'name': 'SoilTempArray'},
   {'interface': ISequence, 'name': 'rSoilTempArrayRate'}],
                             elt_factory={  2: ('amei.soiltemperature.soiltemperature', 'SnowCoverCalculator'),
   3: ('amei.soiltemperature.soiltemperature', 'STMPsimCalculator')},
                             elt_connections={  4337502352: (2, 1, '__out__', 0),
   4337502384: (2, 6, '__out__', 1),
   4337502416: (2, 0, '__out__', 2),
   4337502448: (2, 3, '__out__', 3),
   4337502480: (2, 4, '__out__', 4),
   4337502512: (2, 5, '__out__', 5),
   4337502544: (2, 2, '__out__', 6),
   4337502576: (3, 0, '__out__', 7),
   4337502608: (3, 1, '__out__', 8),
   4337502640: ('__in__', 0, 2, 0),
   4337502672: ('__in__', 1, 2, 3),
   4337502704: ('__in__', 2, 2, 1),
   4337502736: ('__in__', 3, 2, 2),
   4337502768: ('__in__', 4, 2, 5),
   4337502800: ('__in__', 5, 2, 6),
   4337502832: ('__in__', 6, 2, 7),
   4337502864: ('__in__', 7, 2, 8),
   4337502896: ('__in__', 8, 2, 9),
   4337502928: ('__in__', 9, 2, 10),
   4337502960: ('__in__', 10, 2, 11),
   4337502992: ('__in__', 11, 2, 12),
   4337503024: ('__in__', 12, 2, 13),
   4337503056: ('__in__', 13, 2, 14),
   4337503088: ('__in__', 14, 3, 0),
   4337503120: ('__in__', 15, 3, 1),
   4337503152: ('__in__', 16, 3, 2),
   4337503184: ('__in__', 17, 3, 3),
   4337503216: ('__in__', 18, 3, 4),
   4337503248: ('__in__', 19, 3, 5),
   4337503280: ('__in__', 20, 2, 4),
   4337503312: ('__in__', 21, 2, 15),
   4337503344: ('__in__', 22, 2, 16),
   4337503376: ('__in__', 23, 2, 17),
   4337503408: ('__in__', 24, 3, 8),
   4337503440: ('__in__', 25, 3, 9),
   4337503472: (2, 1, 3, 6)},
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




