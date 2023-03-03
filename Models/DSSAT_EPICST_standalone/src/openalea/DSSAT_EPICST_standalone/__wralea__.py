
# -*- coding: latin-1 -*-
# This file has been generated at Fri Mar  3 09:18:48 2023

from openalea.core import *


__name__ = 'amei.dssat_'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['STEMP_EPIC_']


__all__ = ['stemp_epic_model_stemp_epic', '_2484213968456']



stemp_epic_model_stemp_epic = Factory(name='STEMP_EPIC',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='stemp_epic',
                nodeclass='model_stemp_epic',
                inputs=[{'name': 'NL', 'interface': IInt, 'value': 0}, {'name': 'ISWWAT', 'interface': IStr, 'value': 'Y'}, {'name': 'BD', 'interface': ISequence, 'value': 0}, {'name': 'DLAYR', 'interface': ISequence, 'value': 0}, {'name': 'DS', 'interface': ISequence, 'value': 0}, {'name': 'DUL', 'interface': ISequence, 'value': 0}, {'name': 'LL', 'interface': ISequence, 'value': 0}, {'name': 'NLAYR', 'interface': IInt, 'value': 0}, {'name': 'TAMP', 'interface': IFloat, 'value': 0}, {'name': 'RAIN', 'interface': IFloat, 'value': 0}, {'name': 'SW', 'interface': ISequence, 'value': 0}, {'name': 'TAVG', 'interface': IFloat, 'value': 0}, {'name': 'TMAX', 'interface': IFloat, 'value': 0}, {'name': 'TMIN', 'interface': IFloat, 'value': 0}, {'name': 'TAV', 'interface': IFloat, 'value': 0}, {'name': 'CUMDPT', 'interface': IFloat, 'value': 0}, {'name': 'DSMID', 'interface': ISequence, 'value': 0}, {'name': 'TMA', 'interface': ISequence, 'value': 0}, {'name': 'NDays', 'interface': IInt, 'value': 0}, {'name': 'WetDay', 'interface': ISequence, 'value': 0}, {'name': 'X2_PREV', 'interface': IFloat, 'value': 0}, {'name': 'SRFTEMP', 'interface': IFloat, 'value': 0}, {'name': 'ST', 'interface': ISequence, 'value': 0}, {'name': 'DEPIR', 'interface': IFloat, 'value': 0}, {'name': 'BIOMAS', 'interface': IFloat, 'value': 0}, {'name': 'MULCHMASS', 'interface': IFloat, 'value': 0}, {'name': 'SNOW', 'interface': IFloat, 'value': 0}],
                outputs=[{'name': 'CUMDPT', 'interface': IFloat}, {'name': 'DSMID', 'interface': ISequence}, {'name': 'TMA', 'interface': ISequence}, {'name': 'NDays', 'interface': IInt}, {'name': 'WetDay', 'interface': ISequence}, {'name': 'X2_PREV', 'interface': IFloat}, {'name': 'SRFTEMP', 'interface': IFloat}, {'name': 'ST', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




_2484213968456 = CompositeNodeFactory(name='STEMP_EPIC_',
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
                             inputs=[  {'interface': ISequence, 'name': 'DLAYR'},
   {'interface': IStr, 'name': 'ISWWAT', 'value': 'Y'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IFloat, 'name': 'SNOW'},
   {'interface': IFloat, 'name': 'TAMP'},
   {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': IFloat, 'name': 'DEPIR'},
   {'interface': IFloat, 'name': 'TMIN'},
   {'interface': ISequence, 'name': 'ST'},
   {'interface': IInt, 'name': 'NL'},
   {'interface': ISequence, 'name': 'SW'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IFloat, 'name': 'MULCHMASS'},
   {'interface': IFloat, 'name': 'TAVG'},
   {'interface': ISequence, 'name': 'BD'},
   {'interface': IInt, 'name': 'NLAYR'},
   {'interface': IFloat, 'name': 'TAV'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': IInt, 'name': 'NDays'},
   {'interface': ISequence, 'name': 'DS'},
   {'interface': IFloat, 'name': 'TMAX'},
   {'interface': ISequence, 'name': 'DUL'},
   {'interface': IFloat, 'name': 'BIOMAS'},
   {'interface': IFloat, 'name': 'X2_PREV'},
   {'interface': ISequence, 'name': 'WetDay'},
   {'interface': ISequence, 'name': 'LL'},
   {'interface': IFloat, 'name': 'RAIN'}],
                             outputs=[  {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IInt, 'name': 'NDays'},
   {'interface': ISequence, 'name': 'WetDay'},
   {'interface': IFloat, 'name': 'X2_PREV'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'ST'}],
                             elt_factory={2: ('amei.dssat_.stemp_epic_', 'STEMP_EPIC')},
                             elt_connections={  140732969689456: (2, 0, '__out__', 0),
   140732969689488: (2, 1, '__out__', 1),
   140732969689520: (2, 2, '__out__', 2),
   140732969689552: (2, 3, '__out__', 3),
   140732969689584: (2, 4, '__out__', 4),
   140732969689616: (2, 5, '__out__', 5),
   140732969689648: (2, 6, '__out__', 6),
   140732969689680: (2, 7, '__out__', 7),
   140732969689712: ('__in__', 0, 2, 9),
   140732969689744: ('__in__', 1, 2, 14),
   140732969689776: ('__in__', 2, 2, 18),
   140732969689808: ('__in__', 3, 2, 15),
   140732969689840: ('__in__', 4, 2, 21),
   140732969689872: ('__in__', 5, 2, 3),
   140732969689904: ('__in__', 6, 2, 10),
   140732969689936: ('__in__', 7, 2, 19),
   140732969689968: ('__in__', 8, 2, 20),
   140732969690000: ('__in__', 9, 2, 2),
   140732969690032: ('__in__', 10, 2, 1),
   140732969690064: ('__in__', 11, 2, 11),
   140732969690096: ('__in__', 12, 2, 25),
   140732969690128: ('__in__', 13, 2, 4),
   140732969690160: ('__in__', 14, 2, 23),
   140732969690192: ('__in__', 15, 2, 17),
   140732969690224: ('__in__', 16, 2, 16),
   140732969690256: ('__in__', 17, 2, 26),
   140732969690288: ('__in__', 18, 2, 22),
   140732969690320: ('__in__', 19, 2, 12),
   140732969690352: ('__in__', 20, 2, 24),
   140732969690384: ('__in__', 21, 2, 5),
   140732969690416: ('__in__', 22, 2, 8),
   140732969690448: ('__in__', 23, 2, 6),
   140732969690480: ('__in__', 24, 2, 0),
   140732969690512: ('__in__', 25, 2, 13),
   140732969690544: ('__in__', 26, 2, 7)},
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




