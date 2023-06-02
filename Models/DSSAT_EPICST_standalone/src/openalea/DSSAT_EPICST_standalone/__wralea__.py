
# This file has been generated at Thu May 25 10:58:55 2023

from openalea.core import *


__name__ = 'amei.dssat_.stemp_epic_'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['STEMP_EPIC_']


__all__ = ['stemp_epic_model_stemp_epic', '_2414960696328']



stemp_epic_model_stemp_epic = Factory(name='STEMP_EPIC',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='stemp_epic',
                nodeclass='model_stemp_epic',
                inputs=[{'name': 'NL', 'interface': IInt, 'value': 0}, {'name': 'ISWWAT', 'interface': IStr, 'value': 'Y'}, {'name': 'BD', 'interface': ISequence, 'value': 0}, {'name': 'DLAYR', 'interface': ISequence, 'value': 0}, {'name': 'DS', 'interface': ISequence, 'value': 0}, {'name': 'DUL', 'interface': ISequence, 'value': 0}, {'name': 'LL', 'interface': ISequence, 'value': 0}, {'name': 'NLAYR', 'interface': IInt, 'value': 0}, {'name': 'TAMP', 'interface': IFloat, 'value': 0}, {'name': 'RAIN', 'interface': IFloat, 'value': 0}, {'name': 'SW', 'interface': ISequence, 'value': 0}, {'name': 'TAVG', 'interface': IFloat, 'value': 0}, {'name': 'TMAX', 'interface': IFloat, 'value': 0}, {'name': 'TMIN', 'interface': IFloat, 'value': 0}, {'name': 'TAV', 'interface': IFloat, 'value': 0}, {'name': 'CUMDPT', 'interface': IFloat, 'value': 0}, {'name': 'DSMID', 'interface': ISequence, 'value': 0}, {'name': 'TDL', 'interface': IFloat, 'value': 0}, {'name': 'TMA', 'interface': ISequence, 'value': 0}, {'name': 'NDays', 'interface': IInt, 'value': 0}, {'name': 'WetDay', 'interface': ISequence, 'value': 0}, {'name': 'X2_PREV', 'interface': IFloat, 'value': 0}, {'name': 'SRFTEMP', 'interface': IFloat, 'value': 0}, {'name': 'ST', 'interface': ISequence, 'value': 0}, {'name': 'DEPIR', 'interface': IFloat, 'value': 0}, {'name': 'BIOMAS', 'interface': IFloat, 'value': 0}, {'name': 'MULCHMASS', 'interface': IFloat, 'value': 0}, {'name': 'SNOW', 'interface': IFloat, 'value': 0}],
                outputs=[{'name': 'CUMDPT', 'interface': IFloat}, {'name': 'DSMID', 'interface': ISequence}, {'name': 'TDL', 'interface': IFloat}, {'name': 'TMA', 'interface': ISequence}, {'name': 'NDays', 'interface': IInt}, {'name': 'WetDay', 'interface': ISequence}, {'name': 'X2_PREV', 'interface': IFloat}, {'name': 'SRFTEMP', 'interface': IFloat}, {'name': 'ST', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




_2414960696328 = CompositeNodeFactory(name='STEMP_EPIC_',
                             description=('\n'
 '\n'
 '    STEMP_EPIC_ model\n'
 '    -Version:  1.0  -Time step:  1\n'
 '    Authors: Kenneth N. Potter , Jimmy R. Williams \n'
 '    Reference: https://doi.org/10.2134/agronj1994.00021962008600060014x\n'
 '    Institution: USDA-ARS, USDA-ARS\n'
 '    ExtendedDescription: None\n'
 '    ShortDescription: Determines soil temperature by layer test encore\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': ISequence, 'name': 'BD'},
   {'interface': IFloat, 'name': 'RAIN'},
   {'interface': IInt, 'name': 'NDays'},
   {'interface': IFloat, 'name': 'DEPIR'},
   {'interface': IFloat, 'name': 'TMIN'},
   {'interface': ISequence, 'name': 'WetDay'},
   {'interface': ISequence, 'name': 'DUL'},
   {'interface': IFloat, 'name': 'BIOMAS'},
   {'interface': ISequence, 'name': 'DS'},
   {'interface': IFloat, 'name': 'TAMP'},
   {'interface': ISequence, 'name': 'DLAYR'},
   {'interface': IFloat, 'name': 'MULCHMASS'},
   {'interface': ISequence, 'name': 'LL'},
   {'interface': IFloat, 'name': 'TDL'},
   {'interface': IFloat, 'name': 'X2_PREV'},
   {'interface': ISequence, 'name': 'SW'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IInt, 'name': 'NLAYR'},
   {'interface': IFloat, 'name': 'TMAX'},
   {'interface': IFloat, 'name': 'TAV'},
   {'interface': IFloat, 'name': 'SNOW'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IFloat, 'name': 'TAVG'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'ST'},
   {'interface': IInt, 'name': 'NL'},
   {'interface': IStr, 'name': 'ISWWAT', 'value': 'Y'},
   {'interface': IFloat, 'name': 'CUMDPT'}],
                             outputs=[  {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IFloat, 'name': 'TDL'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IInt, 'name': 'NDays'},
   {'interface': ISequence, 'name': 'WetDay'},
   {'interface': IFloat, 'name': 'X2_PREV'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'ST'}],
                             elt_factory={2: ('amei.dssat_.stemp_epic_', 'STEMP_EPIC')},
                             elt_connections={  140710337028464: (2, 0, '__out__', 0),
   140710337028496: (2, 1, '__out__', 1),
   140710337028528: (2, 2, '__out__', 2),
   140710337028560: (2, 3, '__out__', 3),
   140710337028592: (2, 4, '__out__', 4),
   140710337028624: (2, 5, '__out__', 5),
   140710337028656: (2, 6, '__out__', 6),
   140710337028688: (2, 7, '__out__', 7),
   140710337028720: (2, 8, '__out__', 8),
   140710337028752: ('__in__', 0, 2, 2),
   140710337028784: ('__in__', 1, 2, 9),
   140710337028816: ('__in__', 2, 2, 19),
   140710337028848: ('__in__', 3, 2, 24),
   140710337028880: ('__in__', 4, 2, 13),
   140710337028912: ('__in__', 5, 2, 20),
   140710337028944: ('__in__', 6, 2, 5),
   140710337028976: ('__in__', 7, 2, 25),
   140710337029008: ('__in__', 8, 2, 4),
   140710337029040: ('__in__', 9, 2, 8),
   140710337029072: ('__in__', 10, 2, 3),
   140710337029104: ('__in__', 11, 2, 26),
   140710337029136: ('__in__', 12, 2, 6),
   140710337029168: ('__in__', 13, 2, 17),
   140710337029200: ('__in__', 14, 2, 21),
   140710337029232: ('__in__', 15, 2, 10),
   140710337029264: ('__in__', 16, 2, 16),
   140710337029296: ('__in__', 17, 2, 7),
   140710337029328: ('__in__', 18, 2, 12),
   140710337029360: ('__in__', 19, 2, 14),
   140710337029392: ('__in__', 20, 2, 27),
   140710337029424: ('__in__', 21, 2, 18),
   140710337029456: ('__in__', 22, 2, 11),
   140710337029488: ('__in__', 23, 2, 22),
   140710337029520: ('__in__', 24, 2, 23),
   140710337029552: ('__in__', 25, 2, 0),
   140710337029584: ('__in__', 26, 2, 1),
   140710337029616: ('__in__', 27, 2, 15)},
                             elt_data={  2: {  'block': False,
         'caption': 'STEMP_EPIC',
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




