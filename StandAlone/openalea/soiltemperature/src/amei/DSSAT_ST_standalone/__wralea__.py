
# This file has been generated at Wed Mar  1 23:57:10 2023

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


__all__ = ['stemp_model_stemp', '_2188876717384']



stemp_model_stemp = Factory(name='STEMP',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='stemp',
                nodeclass='model_stemp',
                inputs=[{'name': 'NL', 'interface': IInt, 'value': 0}, {'name': 'ISWWAT', 'interface': IStr, 'value': 'Y'}, {'name': 'BD', 'interface': ISequence, 'value': 0}, {'name': 'DLAYR', 'interface': ISequence, 'value': 0}, {'name': 'DS', 'interface': ISequence, 'value': 0}, {'name': 'DUL', 'interface': ISequence, 'value': 0}, {'name': 'LL', 'interface': ISequence, 'value': 0}, {'name': 'NLAYR', 'interface': IInt, 'value': 0}, {'name': 'MSALB', 'interface': IFloat, 'value': 0}, {'name': 'SRAD', 'interface': IFloat, 'value': 0}, {'name': 'SW', 'interface': ISequence, 'value': 0}, {'name': 'TAVG', 'interface': IFloat, 'value': 0}, {'name': 'TMAX', 'interface': IFloat, 'value': 0}, {'name': 'XLAT', 'interface': IFloat, 'value': 0}, {'name': 'TAV', 'interface': IFloat, 'value': 0}, {'name': 'TAMP', 'interface': IFloat, 'value': 0}, {'name': 'CUMDPT', 'interface': IFloat, 'value': 0}, {'name': 'DSMID', 'interface': ISequence, 'value': 0}, {'name': 'TMA', 'interface': ISequence, 'value': 0}, {'name': 'ATOT', 'interface': IFloat, 'value': 0}, {'name': 'SRFTEMP', 'interface': IFloat, 'value': 0}, {'name': 'ST', 'interface': ISequence, 'value': 0}, {'name': 'DOY', 'interface': IInt, 'value': 0}],
                outputs=[{'name': 'CUMDPT', 'interface': IFloat}, {'name': 'DSMID', 'interface': ISequence}, {'name': 'TMA', 'interface': ISequence}, {'name': 'ATOT', 'interface': IFloat}, {'name': 'SRFTEMP', 'interface': IFloat}, {'name': 'ST', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




_2188876717384 = CompositeNodeFactory(name='STEMP_',
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
                             inputs=[  {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IFloat, 'name': 'TAVG'},
   {'interface': ISequence, 'name': 'ST'},
   {'interface': IFloat, 'name': 'TMAX'},
   {'interface': IFloat, 'name': 'TAV'},
   {'interface': ISequence, 'name': 'DLAYR'},
   {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': ISequence, 'name': 'SW'},
   {'interface': IFloat, 'name': 'TAMP'},
   {'interface': IInt, 'name': 'NLAYR'},
   {'interface': IInt, 'name': 'DOY'},
   {'interface': ISequence, 'name': 'LL'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IStr, 'name': 'ISWWAT', 'value': 'Y'},
   {'interface': ISequence, 'name': 'DUL'},
   {'interface': ISequence, 'name': 'BD'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'DS'},
   {'interface': IInt, 'name': 'NL'},
   {'interface': IFloat, 'name': 'XLAT'},
   {'interface': IFloat, 'name': 'SRAD'},
   {'interface': IFloat, 'name': 'MSALB'},
   {'interface': IFloat, 'name': 'ATOT'}],
                             outputs=[  {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IFloat, 'name': 'ATOT'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'ST'}],
                             elt_factory={2: ('amei.dssat_.stemp_', 'STEMP')},
                             elt_connections={  140732969689456: (2, 0, '__out__', 0),
   140732969689488: (2, 1, '__out__', 1),
   140732969689520: (2, 2, '__out__', 2),
   140732969689552: (2, 3, '__out__', 3),
   140732969689584: (2, 4, '__out__', 4),
   140732969689616: (2, 5, '__out__', 5),
   140732969689648: ('__in__', 0, 2, 17),
   140732969689680: ('__in__', 1, 2, 11),
   140732969689712: ('__in__', 2, 2, 21),
   140732969689744: ('__in__', 3, 2, 12),
   140732969689776: ('__in__', 4, 2, 14),
   140732969689808: ('__in__', 5, 2, 3),
   140732969689840: ('__in__', 6, 2, 16),
   140732969689872: ('__in__', 7, 2, 10),
   140732969689904: ('__in__', 8, 2, 15),
   140732969689936: ('__in__', 9, 2, 7),
   140732969689968: ('__in__', 10, 2, 22),
   140732969690000: ('__in__', 11, 2, 6),
   140732969690032: ('__in__', 12, 2, 18),
   140732969690064: ('__in__', 13, 2, 1),
   140732969690096: ('__in__', 14, 2, 5),
   140732969690128: ('__in__', 15, 2, 2),
   140732969690160: ('__in__', 16, 2, 20),
   140732969690192: ('__in__', 17, 2, 4),
   140732969690224: ('__in__', 18, 2, 0),
   140732969690256: ('__in__', 19, 2, 13),
   140732969690288: ('__in__', 20, 2, 9),
   140732969690320: ('__in__', 21, 2, 8),
   140732969690352: ('__in__', 22, 2, 19)},
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




