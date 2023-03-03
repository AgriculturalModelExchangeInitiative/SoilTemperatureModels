
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


__all__ = ['stemp_epic_model_stemp_epic', '_140426266163728']



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




_140426266163728 = CompositeNodeFactory(name='STEMP_EPIC_',
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
                             inputs=[  {'interface': IFloat, 'name': 'RAIN'},
   {'interface': IFloat, 'name': 'TAV'},
   {'interface': IInt, 'name': 'NDays'},
   {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'DLAYR'},
   {'interface': ISequence, 'name': 'SW'},
   {'interface': ISequence, 'name': 'WetDay'},
   {'interface': IFloat, 'name': 'X2_PREV'},
   {'interface': ISequence, 'name': 'BD'},
   {'interface': IStr, 'name': 'ISWWAT', 'value': 'Y'},
   {'interface': IFloat, 'name': 'TAVG'},
   {'interface': IFloat, 'name': 'MULCHMASS'},
   {'interface': ISequence, 'name': 'DS'},
   {'interface': IFloat, 'name': 'DEPIR'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': IFloat, 'name': 'SNOW'},
   {'interface': ISequence, 'name': 'ST'},
   {'interface': IFloat, 'name': 'TMAX'},
   {'interface': IFloat, 'name': 'BIOMAS'},
   {'interface': ISequence, 'name': 'DUL'},
   {'interface': IFloat, 'name': 'TAMP'},
   {'interface': ISequence, 'name': 'LL'},
   {'interface': IInt, 'name': 'NL'},
   {'interface': IFloat, 'name': 'TMIN'},
   {'interface': IInt, 'name': 'NLAYR'}],
                             outputs=[  {'interface': IFloat, 'name': 'CUMDPT'},
   {'interface': ISequence, 'name': 'DSMID'},
   {'interface': ISequence, 'name': 'TMA'},
   {'interface': IInt, 'name': 'NDays'},
   {'interface': ISequence, 'name': 'WetDay'},
   {'interface': IFloat, 'name': 'X2_PREV'},
   {'interface': IFloat, 'name': 'SRFTEMP'},
   {'interface': ISequence, 'name': 'ST'}],
                             elt_factory={2: ('amei.dssat_', 'STEMP_EPIC')},
                             elt_connections={  4502364480: (2, 0, '__out__', 0),
   4502364512: (2, 1, '__out__', 1),
   4502364544: (2, 2, '__out__', 2),
   4502364576: (2, 3, '__out__', 3),
   4502364608: (2, 4, '__out__', 4),
   4502364640: (2, 5, '__out__', 5),
   4502364672: (2, 6, '__out__', 6),
   4502364704: (2, 7, '__out__', 7),
   4502364736: ('__in__', 0, 2, 9),
   4502364768: ('__in__', 1, 2, 14),
   4502364800: ('__in__', 2, 2, 18),
   4502364832: ('__in__', 3, 2, 15),
   4502364864: ('__in__', 4, 2, 21),
   4502364896: ('__in__', 5, 2, 3),
   4502364928: ('__in__', 6, 2, 10),
   4502364960: ('__in__', 7, 2, 19),
   4502364992: ('__in__', 8, 2, 20),
   4502365024: ('__in__', 9, 2, 2),
   4502365056: ('__in__', 10, 2, 1),
   4502365088: ('__in__', 11, 2, 11),
   4502365120: ('__in__', 12, 2, 25),
   4502365152: ('__in__', 13, 2, 4),
   4502365184: ('__in__', 14, 2, 23),
   4502365216: ('__in__', 15, 2, 17),
   4502365248: ('__in__', 16, 2, 16),
   4502365280: ('__in__', 17, 2, 26),
   4502365312: ('__in__', 18, 2, 22),
   4502365344: ('__in__', 19, 2, 12),
   4502365376: ('__in__', 20, 2, 24),
   4502365408: ('__in__', 21, 2, 5),
   4502365440: ('__in__', 22, 2, 8),
   4502365472: ('__in__', 23, 2, 6),
   4502365504: ('__in__', 24, 2, 0),
   4502365536: ('__in__', 25, 2, 13),
   4502365568: ('__in__', 26, 2, 7)},
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




