
# This file has been generated at Fri Jun  2 23:14:22 2023

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
__alias__ = ['soil_temp']


__all__ = ['temp_amp_model_temp_amp', 'temp_profile_model_temp_profile', 'layers_temp_model_layers_temp', 'canopy_temp_avg_model_canopy_temp_avg', 'update_model_update', '_2960988031048']



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




temp_profile_model_temp_profile = Factory(name='temp_profile',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='temp_profile',
                nodeclass='model_temp_profile',
                inputs=[{'name': 'temp_amp', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'prev_temp_profile', 'interface': ISequence, 'value': 0}, {'name': 'prev_canopy_temp', 'interface': IFloat(min=0, max=50, step=1.000000), 'value': 0}, {'name': 'min_air_temp', 'interface': IFloat(min=-50, max=50, step=1.000000), 'value': 0}, {'name': 'air_temp_day1', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 0.0}, {'name': 'layer_thick', 'interface': ISequence, 'value': 0}],
                outputs=[{'name': 'temp_profile', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




layers_temp_model_layers_temp = Factory(name='layers_temp',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='layers_temp',
                nodeclass='model_layers_temp',
                inputs=[{'name': 'temp_profile', 'interface': ISequence, 'value': 0.0}, {'name': 'layer_thick', 'interface': ISequence, 'value': 0}],
                outputs=[{'name': 'layer_temp', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




canopy_temp_avg_model_canopy_temp_avg = Factory(name='canopy_temp_avg',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='canopy_temp_avg',
                nodeclass='model_canopy_temp_avg',
                inputs=[{'name': 'min_canopy_temp', 'interface': IFloat(min=-50, max=50, step=1.000000), 'value': 0.0}, {'name': 'max_canopy_temp', 'interface': IFloat(min=-50, max=50, step=1.000000), 'value': 0.0}],
                outputs=[{'name': 'canopy_temp_avg', 'interface': IFloat(min=0, max=100, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




update_model_update = Factory(name='update',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='update',
                nodeclass='model_update',
                inputs=[{'name': 'canopy_temp_avg', 'interface': IFloat(min=-50, max=50, step=1.000000), 'value': 0.0}, {'name': 'temp_profile', 'interface': ISequence, 'value': 0}],
                outputs=[{'name': 'prev_canopy_temp', 'interface': IFloat(min=0, max=50, step=1.000000)}, {'name': 'prev_temp_profile', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




_2960988031048 = CompositeNodeFactory(name='soil_temp',
                             description=('\n'
 '\n'
 '    soil temperature model\n'
 '    -Version: 1.0  -Time step: 1\n'
 '    Authors: None\n'
 '    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002\n'
 '    Institution: INRAE\n'
 '    ExtendedDescription: None\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat(min=-50, max=50, step=1.000000), 'name': 'min_temp'},
   {'interface': IFloat(min=-50, max=50, step=1.000000), 'name': 'max_temp'},
   {'interface': ISequence, 'name': 'prev_temp_profile'},
   {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'prev_canopy_temp'},
   {  'interface': IFloat(min=-50, max=50, step=1.000000),
      'name': 'min_air_temp'},
   {  'interface': IFloat(min=0, max=100, step=1.000000),
      'name': 'air_temp_day1'},
   {'interface': ISequence, 'name': 'layer_thick'},
   {  'interface': IFloat(min=-50, max=50, step=1.000000),
      'name': 'min_canopy_temp'},
   {  'interface': IFloat(min=-50, max=50, step=1.000000),
      'name': 'max_canopy_temp'}],
                             outputs=[  {'interface': IFloat(min=0, max=100, step=1.000000), 'name': 'temp_amp'},
   {'interface': ISequence, 'name': 'temp_profile'},
   {'interface': ISequence, 'name': 'layer_temp'},
   {  'interface': IFloat(min=0, max=100, step=1.000000),
      'name': 'canopy_temp_avg'},
   {  'interface': IFloat(min=0, max=50, step=1.000000),
      'name': 'prev_canopy_temp'},
   {'interface': ISequence, 'name': 'prev_temp_profile'}],
                             elt_factory={  2: ('amei.stics.soiltemperature', 'temp_amp'),
   3: ('amei.stics.soiltemperature', 'temp_profile'),
   4: ('amei.stics.soiltemperature', 'layers_temp'),
   5: ('amei.stics.soiltemperature', 'canopy_temp_avg'),
   6: ('amei.stics.soiltemperature', 'update')},
                             elt_connections={  140717222306160: (2, 0, '__out__', 0),
   140717222306192: (3, 0, '__out__', 1),
   140717222306224: (4, 0, '__out__', 2),
   140717222306256: (5, 0, '__out__', 3),
   140717222306288: (6, 0, '__out__', 4),
   140717222306320: (6, 1, '__out__', 5),
   140717222306352: ('__in__', 0, 2, 0),
   140717222306384: ('__in__', 1, 2, 1),
   140717222306416: ('__in__', 2, 3, 1),
   140717222306448: ('__in__', 3, 3, 2),
   140717222306480: ('__in__', 4, 3, 3),
   140717222306512: ('__in__', 5, 3, 4),
   140717222306544: ('__in__', 6, 3, 5),
   140717222306576: ('__in__', 6, 4, 1),
   140717222306608: ('__in__', 7, 5, 0),
   140717222306640: ('__in__', 8, 5, 1),
   140717222306672: (2, 0, 3, 0),
   140717222306704: (3, 0, 4, 0),
   140717222306736: (3, 0, 6, 1),
   140717222306768: (5, 0, 6, 0)},
                             elt_data={  2: {  'block': False,
         'caption': 'temp_amp',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': -83,
         'posy': 125.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   3: {  'block': False,
         'caption': 'temp_profile',
         'delay': 0,
         'hide': True,
         'id': 3,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': -27.444444444444443,
         'posy': 125.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   4: {  'block': False,
         'caption': 'layers_temp',
         'delay': 0,
         'hide': True,
         'id': 4,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 28.111111111111114,
         'posy': 125.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   5: {  'block': False,
         'caption': 'canopy_temp_avg',
         'delay': 0,
         'hide': True,
         'id': 5,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 83.66666666666667,
         'posy': 125.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   6: {  'block': False,
         'caption': 'update',
         'delay': 0,
         'hide': True,
         'id': 6,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 56.66666666666667,
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
                             elt_value={2: [], 3: [], 4: [], 5: [], 6: [], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [-83, 125.0], 'userColor': None, 'useUserColor': True},
   3: {'position': [-27.444444444444443, 125.0], 'userColor': None, 'useUserColor': True},
   4: {'position': [28.111111111111114, 125.0], 'userColor': None, 'useUserColor': True},
   5: {'position': [83.66666666666667, 125.0], 'userColor': None, 'useUserColor': True},
   6: {'position': [56.66666666666667, 250.0], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




