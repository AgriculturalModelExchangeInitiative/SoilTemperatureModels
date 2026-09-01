
# -*- coding: latin-1 -*-
# This file has been generated at Tue Sep  1 09:17:41 2026

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


__all__ = ['stemp_model_stemp', '_1330703231744']



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




_1330703231744 = CompositeNodeFactory(name='STEMP_',
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
                             elt_connections={  1330507022544: (2, 0, '__out__', 0),
   1330507022576: (2, 1, '__out__', 1),
   1330507022608: (2, 2, '__out__', 2),
   1330507022640: (2, 3, '__out__', 3),
   1330507022672: (2, 4, '__out__', 4),
   1330507022704: (2, 5, '__out__', 5),
   1330507022736: (2, 6, '__out__', 6),
   1330507022768: ('__in__', 0, 2, 12),
   1330507022800: ('__in__', 1, 2, 8),
   1330507022832: ('__in__', 2, 2, 24),
   1330507022864: ('__in__', 3, 2, 0),
   1330507022896: ('__in__', 4, 2, 21),
   1330507022928: ('__in__', 5, 2, 6),
   1330507022960: ('__in__', 6, 2, 7),
   1330507022992: ('__in__', 7, 2, 4),
   1330507023024: ('__in__', 8, 2, 22),
   1330507023056: ('__in__', 9, 2, 9),
   1330507023088: ('__in__', 10, 2, 15),
   1330507023120: ('__in__', 11, 2, 3),
   1330507023152: ('__in__', 12, 2, 19),
   1330507023184: ('__in__', 13, 2, 18),
   1330507023216: ('__in__', 14, 2, 1),
   1330507023248: ('__in__', 15, 2, 16),
   1330507023280: ('__in__', 16, 2, 11),
   1330507023312: ('__in__', 17, 2, 2),
   1330507023344: ('__in__', 18, 2, 10),
   1330507023376: ('__in__', 19, 2, 20),
   1330507023408: ('__in__', 20, 2, 14),
   1330507023440: ('__in__', 21, 2, 13),
   1330507023472: ('__in__', 22, 2, 5),
   1330507023504: ('__in__', 23, 2, 17),
   1330507023536: ('__in__', 24, 2, 23)},
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




