
# -*- coding: latin-1 -*-
# This file has been generated at Fri Mar  3 09:19:20 2023

from openalea.core import *


__name__ = 'amei.stics.soiltemperature'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['Soiltemp']


__all__ = ['temp_amp_model_temp_amp', 'therm_amp_model_therm_amp', 'temp_profile_model_temp_profile', 'Soiltemp']



temp_amp_model_temp_amp = Factory(name='temp_amp',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='temp_amp',
                nodeclass='model_temp_amp',
                inputs=[{'name': 'min_temp', 'interface': IFloat(min=-50, max=50, step=1.000000), 'value': 0.0}, {'name': 'max_temp', 'interface': IFloat(min=-50, max=50, step=1.000000), 'value': 0.0}],
                outputs=[{'name': 'temp_amp', 'interface': IFloat(min=0, max=100, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




therm_amp_model_therm_amp = Factory(name='therm_amp',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='therm_amp',
                nodeclass='model_therm_amp',
                inputs=[{'name': 'therm_diff', 'interface': IFloat(min=0, max=0, step=1.000000), 'value': 0.00537}, {'name': 'temp_wave_freq', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 7.272e-05}],
                outputs=[{'name': 'therm_amp', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




temp_profile_model_temp_profile = Factory(name='temp_profile',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='temp_profile',
                nodeclass='model_temp_profile',
                inputs=[{'name': 'temp_amp', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'therm_amp', 'interface': IFloat, 'value': 0}, {'name': 'prev_temp_profile', 'interface': ISequence, 'value': 0}, {'name': 'prev_canopy_temp', 'interface': IFloat(min=0, max=50, step=1.000000), 'value': 0}, {'name': 'min_air_temp', 'interface': IFloat(min=-50, max=50, step=1.000000), 'value': 0}],
                outputs=[{'name': 'temp_profile', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




Soiltemp = CompositeNodeFactory(name='Soiltemp',
                             description=('\n'
 '\n'
 '    soiltemp model\n'
 '    -Version: 1.0  -Time step: 1\n'
 '    Authors: None\n'
 '    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002\n'
 '    Institution: INRAE\n'
 '    ExtendedDescription: None\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat(min=-50, max=50, step=1.000000), 'name': 'max_temp'},
   {'interface': IFloat(min=-50, max=50, step=1.000000), 'name': 'min_temp'},
   {  'interface': IFloat(min=0, max=0, step=1.000000),
      'name': 'therm_diff',
      'value': 0.00537},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'temp_wave_freq',
      'value': 7.272e-05},
   {'interface': ISequence, 'name': 'prev_temp_profile'},
   {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'prev_canopy_temp'},
   {  'interface': IFloat(min=-50, max=50, step=1.000000),
      'name': 'min_air_temp'}],
                             outputs=[  {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'temp_amp'},
   {'interface': IFloat, 'name': 'therm_amp'},
   {'interface': ISequence, 'name': 'temp_profile'}],
                             elt_factory={  2: ('amei.stics.soiltemperature', 'temp_amp'),
   3: ('amei.stics.soiltemperature', 'therm_amp'),
   4: ('amei.stics.soiltemperature', 'temp_profile')},
                             elt_connections={  4477251904: (2, 0, '__out__', 0),
   4477251936: (3, 0, '__out__', 1),
   4477251968: (4, 0, '__out__', 2),
   4477252000: ('__in__', 0, 2, 1),
   4477252032: ('__in__', 1, 2, 0),
   4477252064: ('__in__', 2, 3, 0),
   4477252096: ('__in__', 3, 3, 1),
   4477252128: ('__in__', 4, 4, 2),
   4477252160: ('__in__', 5, 4, 3),
   4477252192: ('__in__', 6, 4, 4),
   4477252224: (2, 0, 4, 0),
   4477252256: (3, 0, 4, 1)},
                             elt_data={  2: {  'block': False,
         'caption': 'temp_amp',
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
         'caption': 'therm_amp',
         'delay': 0,
         'hide': True,
         'id': 3,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 0.0,
         'posy': 166.66666666666666,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   4: {  'block': False,
         'caption': 'temp_profile',
         'delay': 0,
         'hide': True,
         'id': 4,
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
                             elt_value={2: [], 3: [], 4: [], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [-125, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   3: {'position': [0.0, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   4: {'position': [125.0, 166.66666666666666], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




