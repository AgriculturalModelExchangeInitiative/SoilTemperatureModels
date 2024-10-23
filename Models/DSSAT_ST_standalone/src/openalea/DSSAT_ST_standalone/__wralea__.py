
# This file has been generated at Wed Nov 29 20:11:45 2023

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


__all__ = ['stemp_model_stemp', '_1871572980040']



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




_1871572980040 = CompositeNodeFactory(name='STEMP_',
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
                             inputs=[  {'interface': IFloat, 'name': 'TMAX'},
   {'interface': IFloat, 'name': 'MSALB'},
   {'interface': IFloat, 'name': 'HDAY'},
   {'interface': IInt, 'name': 'NL'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'LL'},
   {'interface': IInt, 'name': 'NLAYR'},
   {'interface': ISequence, 'name': 'DS'},
   {'interface': ISequence, 'name': 'ST'},
   {'interface': IFloat, 'name': 'SRAD'},
   {'interface': IFloat, 'name': 'TAMP'},
   {'interface': ISequence, 'name': 'DLAYR'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IFloat, 'name': 'TDL'},
   {'interface': IStr, 'name': 'ISWWAT', 'value': 'Y'},
   {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': IFloat, 'name': 'TAVG'},
   {'interface': ISequence, 'name': 'BD'},
   {'interface': ISequence, 'name': 'SW'},
   {'interface': IFloat, 'name': 'ATOT'},
   {'interface': IFloat, 'name': 'TAV'},
   {'interface': IFloat, 'name': 'XLAT'},
   {'interface': ISequence, 'name': 'DUL'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IInt, 'name': 'DOY'}],
                             outputs=[  {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IFloat, 'name': 'TDL'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IFloat, 'name': 'ATOT'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'ST'}],
                             elt_factory={2: ('amei.dssat_.stemp_', 'STEMP')},
                             elt_connections={  140703414264176: (2, 0, '__out__', 0),
   140703414264208: (2, 1, '__out__', 1),
   140703414264240: (2, 2, '__out__', 2),
   140703414264272: (2, 3, '__out__', 3),
   140703414264304: (2, 4, '__out__', 4),
   140703414264336: (2, 5, '__out__', 5),
   140703414264368: (2, 6, '__out__', 6),
   140703414264400: ('__in__', 0, 2, 12),
   140703414264432: ('__in__', 1, 2, 8),
   140703414264464: ('__in__', 2, 2, 24),
   140703414264496: ('__in__', 3, 2, 0),
   140703414264528: ('__in__', 4, 2, 21),
   140703414264560: ('__in__', 5, 2, 6),
   140703414264592: ('__in__', 6, 2, 7),
   140703414264624: ('__in__', 7, 2, 4),
   140703414264656: ('__in__', 8, 2, 22),
   140703414264688: ('__in__', 9, 2, 9),
   140703414264720: ('__in__', 10, 2, 15),
   140703414264752: ('__in__', 11, 2, 3),
   140703414264784: ('__in__', 12, 2, 19),
   140703414264816: ('__in__', 13, 2, 18),
   140703414264848: ('__in__', 14, 2, 1),
   140703414264880: ('__in__', 15, 2, 16),
   140703414264912: ('__in__', 16, 2, 11),
   140703414264944: ('__in__', 17, 2, 2),
   140703414264976: ('__in__', 18, 2, 10),
   140703414265008: ('__in__', 19, 2, 20),
   140703414265040: ('__in__', 20, 2, 14),
   140703414265072: ('__in__', 21, 2, 13),
   140703414265104: ('__in__', 22, 2, 5),
   140703414265136: ('__in__', 23, 2, 17),
   140703414265168: ('__in__', 24, 2, 23)},
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




