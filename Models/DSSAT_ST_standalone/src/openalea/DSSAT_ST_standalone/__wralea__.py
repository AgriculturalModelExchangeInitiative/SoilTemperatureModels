
# This file has been generated at Thu May  4 14:45:42 2023

from openalea.core import *


__name__ = 'amei.dssat_.stemp_'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['STEMP_']


__all__ = ['stemp_model_stemp', '_2696719706632']



stemp_model_stemp = Factory(name='STEMP',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='stemp',
                nodeclass='model_stemp',
                inputs=[{'name': 'NL', 'interface': IInt, 'value': 0}, {'name': 'ISWWAT', 'interface': IStr, 'value': 'Y'}, {'name': 'BD', 'interface': ISequence, 'value': 0}, {'name': 'DLAYR', 'interface': ISequence, 'value': 0}, {'name': 'DS', 'interface': ISequence, 'value': 0}, {'name': 'DUL', 'interface': ISequence, 'value': 0}, {'name': 'LL', 'interface': ISequence, 'value': 0}, {'name': 'NLAYR', 'interface': IInt, 'value': 0}, {'name': 'MSALB', 'interface': IFloat, 'value': 0}, {'name': 'SRAD', 'interface': IFloat, 'value': 0}, {'name': 'SW', 'interface': ISequence, 'value': 0}, {'name': 'TAVG', 'interface': IFloat, 'value': 0}, {'name': 'TMAX', 'interface': IFloat, 'value': 0}, {'name': 'XLAT', 'interface': IFloat, 'value': 0}, {'name': 'TAV', 'interface': IFloat, 'value': 0}, {'name': 'TAMP', 'interface': IFloat, 'value': 0}, {'name': 'CUMDPT', 'interface': IFloat, 'value': 0}, {'name': 'DSMID', 'interface': ISequence, 'value': 0}, {'name': 'TDL', 'interface': IFloat, 'value': 0}, {'name': 'TMA', 'interface': ISequence, 'value': 0}, {'name': 'ATOT', 'interface': IFloat, 'value': 0}, {'name': 'SRFTEMP', 'interface': IFloat, 'value': 0}, {'name': 'ST', 'interface': ISequence, 'value': 0}, {'name': 'DOY', 'interface': IInt, 'value': 0}, {'name': 'HDAY', 'interface': IFloat, 'value': 0}],
                outputs=[{'name': 'CUMDPT', 'interface': IFloat}, {'name': 'DSMID', 'interface': ISequence}, {'name': 'TDL', 'interface': IFloat}, {'name': 'TMA', 'interface': ISequence}, {'name': 'ATOT', 'interface': IFloat}, {'name': 'SRFTEMP', 'interface': IFloat}, {'name': 'ST', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




_2696719706632 = CompositeNodeFactory(name='STEMP_',
                             description=('\n'
 '\n'
 '    STEMP_ model\n'
 '    -Version:  1.0  -Time step:  1\n'
 '    Authors: DSSAT \n'
 '    Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x\n'
 '    Institution: DSSAT Florida\n'
 '    ExtendedDescription: None\n'
 '    ShortDescription: Determines soil temperature by layer\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': IFloat, 'name': 'TAMP'},
   {'interface': IFloat, 'name': 'XLAT'},
   {'interface': IFloat, 'name': 'HDAY'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': IStr, 'name': 'ISWWAT', 'value': 'Y'},
   {'interface': IInt, 'name': 'NLAYR'},
   {'interface': IFloat, 'name': 'ATOT'},
   {'interface': ISequence, 'name': 'DUL'},
   {'interface': IFloat, 'name': 'TDL'},
   {'interface': IFloat, 'name': 'SRAD'},
   {'interface': ISequence, 'name': 'DS'},
   {'interface': ISequence, 'name': 'LL'},
   {'interface': IFloat, 'name': 'TAV'},
   {'interface': IFloat, 'name': 'TMAX'},
   {'interface': IFloat, 'name': 'TAVG'},
   {'interface': ISequence, 'name': 'BD'},
   {'interface': IInt, 'name': 'DOY'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IFloat, 'name': 'MSALB'},
   {'interface': IInt, 'name': 'NL'},
   {'interface': ISequence, 'name': 'DLAYR'},
   {'interface': ISequence, 'name': 'ST'},
   {'interface': ISequence, 'name': 'SW'}],
                             outputs=[  {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IFloat, 'name': 'TDL'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IFloat, 'name': 'ATOT'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'ST'}],
                             elt_factory={2: ('amei.dssat_.stemp_', 'STEMP')},
                             elt_connections={  140722522333552: (2, 0, '__out__', 0),
   140722522333584: (2, 1, '__out__', 1),
   140722522333616: (2, 2, '__out__', 2),
   140722522333648: (2, 3, '__out__', 3),
   140722522333680: (2, 4, '__out__', 4),
   140722522333712: (2, 5, '__out__', 5),
   140722522333744: (2, 6, '__out__', 6),
   140722522333776: ('__in__', 0, 2, 21),
   140722522333808: ('__in__', 1, 2, 15),
   140722522333840: ('__in__', 2, 2, 13),
   140722522333872: ('__in__', 3, 2, 24),
   140722522333904: ('__in__', 4, 2, 19),
   140722522333936: ('__in__', 5, 2, 16),
   140722522333968: ('__in__', 6, 2, 1),
   140722522334000: ('__in__', 7, 2, 7),
   140722522334032: ('__in__', 8, 2, 20),
   140722522334064: ('__in__', 9, 2, 5),
   140722522334096: ('__in__', 10, 2, 18),
   140722522334128: ('__in__', 11, 2, 9),
   140722522334160: ('__in__', 12, 2, 4),
   140722522334192: ('__in__', 13, 2, 6),
   140722522334224: ('__in__', 14, 2, 14),
   140722522334256: ('__in__', 15, 2, 12),
   140722522334288: ('__in__', 16, 2, 11),
   140722522334320: ('__in__', 17, 2, 2),
   140722522334352: ('__in__', 18, 2, 23),
   140722522334384: ('__in__', 19, 2, 17),
   140722522334416: ('__in__', 20, 2, 8),
   140722522334448: ('__in__', 21, 2, 0),
   140722522334480: ('__in__', 22, 2, 3),
   140722522334512: ('__in__', 23, 2, 22),
   140722522334544: ('__in__', 24, 2, 10)},
                             elt_data={  2: {  'block': False,
         'caption': 'STEMP',
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




