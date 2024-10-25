
# -*- coding: latin-1 -*-
# This file has been generated at Fri Oct 25 15:26:49 2024

from openalea.core import *


__name__ = 'amei.campbell.'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['Model_SoilTempCampbell']


__all__ = ['campbell_model_campbell', '_140348687072416']



campbell_model_campbell = Factory(name='Campbell',
                authors='AMEI Consortium (wralea authors)',
                description='TODO',
                category='Unclassified',
                nodemodule='campbell',
                nodeclass='model_campbell',
                inputs=[{'name': 'NLAYR', 'interface': IInt(min=1, max=16777216, step=1), 'value': 10}, {'name': 'THICK', 'interface': ISequence, 'value': 0}, {'name': 'BD', 'interface': ISequence, 'value': 0}, {'name': 'SLCARB', 'interface': ISequence, 'value': 0}, {'name': 'CLAY', 'interface': ISequence, 'value': 50}, {'name': 'SLROCK', 'interface': ISequence, 'value': 0}, {'name': 'SLSILT', 'interface': ISequence, 'value': 0}, {'name': 'SLSAND', 'interface': ISequence, 'value': 0}, {'name': 'SW', 'interface': ISequence, 'value': 0.5}, {'name': 'THICKApsim', 'interface': ISequence, 'value': 0}, {'name': 'DEPTHApsim', 'interface': ISequence, 'value': 0}, {'name': 'CONSTANT_TEMPdepth', 'interface': IFloat, 'value': 1000.0}, {'name': 'BDApsim', 'interface': ISequence, 'value': 0}, {'name': 'T2M', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 0}, {'name': 'TMAX', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 0}, {'name': 'TMIN', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 0}, {'name': 'TAV', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 0}, {'name': 'TAMP', 'interface': IFloat(min=-100, max=100, step=1.000000), 'value': 0}, {'name': 'XLAT', 'interface': IFloat, 'value': 0}, {'name': 'CLAYApsim', 'interface': ISequence, 'value': 0}, {'name': 'SWApsim', 'interface': ISequence, 'value': 0}, {'name': 'DOY', 'interface': IInt(min=1, max=366, step=1), 'value': 1}, {'name': 'airPressure', 'interface': IFloat, 'value': 1010}, {'name': 'canopyHeight', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0.057}, {'name': 'SALB', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0}, {'name': 'SRAD', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}, {'name': 'ESP', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}, {'name': 'ES', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}, {'name': 'EOAD', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}, {'name': 'soilTemp', 'interface': ISequence, 'value': 0}, {'name': 'newTemperature', 'interface': ISequence, 'value': 0}, {'name': 'minSoilTemp', 'interface': ISequence, 'value': 0}, {'name': 'maxSoilTemp', 'interface': ISequence, 'value': 0}, {'name': 'aveSoilTemp', 'interface': ISequence, 'value': 0}, {'name': 'morningSoilTemp', 'interface': ISequence, 'value': 0}, {'name': 'thermalCondPar1', 'interface': ISequence, 'value': 0}, {'name': 'thermalCondPar2', 'interface': ISequence, 'value': 0}, {'name': 'thermalCondPar3', 'interface': ISequence, 'value': 0}, {'name': 'thermalCondPar4', 'interface': ISequence, 'value': 0}, {'name': 'thermalConductivity', 'interface': ISequence, 'value': 0}, {'name': 'thermalConductance', 'interface': ISequence, 'value': 0}, {'name': 'heatStorage', 'interface': ISequence, 'value': 0}, {'name': 'volSpecHeatSoil', 'interface': ISequence, 'value': 0}, {'name': 'maxTempYesterday', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 0}, {'name': 'minTempYesterday', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 0}, {'name': 'instrumentHeight', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 1.2}, {'name': 'boundaryLayerConductanceSource', 'interface': IStr, 'value': 'calc'}, {'name': 'netRadiationSource', 'interface': IStr, 'value': 'calc'}, {'name': 'windSpeed', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 3.0}, {'name': 'SLCARBApsim', 'interface': ISequence, 'value': 0}, {'name': 'SLROCKApsim', 'interface': ISequence, 'value': 0}, {'name': 'SLSILTApsim', 'interface': ISequence, 'value': 0}, {'name': 'SLSANDApsim', 'interface': ISequence, 'value': 0}, {'name': '_boundaryLayerConductance', 'interface': IFloat, 'value': 0}],
                outputs=[{'name': 'soilTemp', 'interface': ISequence}, {'name': 'minSoilTemp', 'interface': ISequence}, {'name': 'maxSoilTemp', 'interface': ISequence}, {'name': 'aveSoilTemp', 'interface': ISequence}, {'name': 'morningSoilTemp', 'interface': ISequence}, {'name': 'newTemperature', 'interface': ISequence}, {'name': 'maxTempYesterday', 'interface': IFloat(min=-60, max=60, step=1.000000)}, {'name': 'minTempYesterday', 'interface': IFloat(min=-60, max=60, step=1.000000)}, {'name': 'thermalCondPar1', 'interface': ISequence}, {'name': 'thermalCondPar2', 'interface': ISequence}, {'name': 'thermalCondPar3', 'interface': ISequence}, {'name': 'thermalCondPar4', 'interface': ISequence}, {'name': 'thermalConductivity', 'interface': ISequence}, {'name': 'thermalConductance', 'interface': ISequence}, {'name': 'heatStorage', 'interface': ISequence}, {'name': 'volSpecHeatSoil', 'interface': ISequence}, {'name': '_boundaryLayerConductance', 'interface': IFloat}, {'name': 'THICKApsim', 'interface': ISequence}, {'name': 'DEPTHApsim', 'interface': ISequence}, {'name': 'BDApsim', 'interface': ISequence}, {'name': 'SWApsim', 'interface': ISequence}, {'name': 'CLAYApsim', 'interface': ISequence}, {'name': 'SLROCKApsim', 'interface': ISequence}, {'name': 'SLCARBApsim', 'interface': ISequence}, {'name': 'SLSANDApsim', 'interface': ISequence}, {'name': 'SLSILTApsim', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




_140348687072416 = CompositeNodeFactory(name='Model_SoilTempCampbell',
                             description=('\n'
 '\n'
 '    SoilTemperature model from Campbell implemented in APSIM\n'
 '    -Version: 1.0  -Time step: 1\n'
 '    Authors: None\n'
 '    Reference: Campbell model (TODO)\n'
 '    Institution: CIRAD and INRAE\n'
 '    ExtendedDescription: TODO\n'
 '    ShortDescription: TODO\n'),
                             category='',
                             doc='',
                             inputs=[  {  'interface': IInt(min=1, max=16777216, step=1),
      'name': 'NLAYR',
      'value': 10},
   {'interface': ISequence, 'name': 'THICK'},
   {'interface': ISequence, 'name': 'BD'},
   {'interface': ISequence, 'name': 'SLCARB'},
   {'interface': ISequence, 'name': 'CLAY', 'value': 50},
   {'interface': ISequence, 'name': 'SLROCK'},
   {'interface': ISequence, 'name': 'SLSILT'},
   {'interface': ISequence, 'name': 'SLSAND'},
   {'interface': ISequence, 'name': 'SW', 'value': 0.5},
   {'interface': ISequence, 'name': 'THICKApsim'},
   {'interface': ISequence, 'name': 'DEPTHApsim'},
   {'interface': IFloat, 'name': 'CONSTANT_TEMPdepth', 'value': 1000.0},
   {'interface': ISequence, 'name': 'BDApsim'},
   {'interface': IFloat(min=-60, max=60, step=1.000000), 'name': 'T2M'},
   {'interface': IFloat(min=-60, max=60, step=1.000000), 'name': 'TMAX'},
   {'interface': IFloat(min=-60, max=60, step=1.000000), 'name': 'TMIN'},
   {'interface': IFloat(min=-60, max=60, step=1.000000), 'name': 'TAV'},
   {'interface': IFloat(min=-100, max=100, step=1.000000), 'name': 'TAMP'},
   {'interface': IFloat, 'name': 'XLAT'},
   {'interface': ISequence, 'name': 'CLAYApsim'},
   {'interface': ISequence, 'name': 'SWApsim'},
   {'interface': IInt(min=1, max=366, step=1), 'name': 'DOY', 'value': 1},
   {'interface': IFloat, 'name': 'airPressure', 'value': 1010},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'canopyHeight',
      'value': 0.057},
   {'interface': IFloat(min=0, max=1, step=1.000000), 'name': 'SALB'},
   {'interface': IFloat(min=0, max=16777216, step=1.000000), 'name': 'SRAD'},
   {'interface': IFloat(min=0, max=16777216, step=1.000000), 'name': 'ESP'},
   {'interface': IFloat(min=0, max=16777216, step=1.000000), 'name': 'ES'},
   {'interface': IFloat(min=0, max=16777216, step=1.000000), 'name': 'EOAD'},
   {'interface': ISequence, 'name': 'soilTemp'},
   {'interface': ISequence, 'name': 'newTemperature'},
   {'interface': ISequence, 'name': 'minSoilTemp'},
   {'interface': ISequence, 'name': 'maxSoilTemp'},
   {'interface': ISequence, 'name': 'aveSoilTemp'},
   {'interface': ISequence, 'name': 'morningSoilTemp'},
   {'interface': ISequence, 'name': 'thermalCondPar1'},
   {'interface': ISequence, 'name': 'thermalCondPar2'},
   {'interface': ISequence, 'name': 'thermalCondPar3'},
   {'interface': ISequence, 'name': 'thermalCondPar4'},
   {'interface': ISequence, 'name': 'thermalConductivity'},
   {'interface': ISequence, 'name': 'thermalConductance'},
   {'interface': ISequence, 'name': 'heatStorage'},
   {'interface': ISequence, 'name': 'volSpecHeatSoil'},
   {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'maxTempYesterday'},
   {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'minTempYesterday'},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'instrumentHeight',
      'value': 1.2},
   {  'interface': IStr,
      'name': 'boundaryLayerConductanceSource',
      'value': 'calc'},
   {'interface': IStr, 'name': 'netRadiationSource', 'value': 'calc'},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'windSpeed',
      'value': 3.0},
   {'interface': ISequence, 'name': 'SLCARBApsim'},
   {'interface': ISequence, 'name': 'SLROCKApsim'},
   {'interface': ISequence, 'name': 'SLSILTApsim'},
   {'interface': ISequence, 'name': 'SLSANDApsim'},
   {'interface': IFloat, 'name': '_boundaryLayerConductance'}],
                             outputs=[  {'interface': ISequence, 'name': 'soilTemp'},
   {'interface': ISequence, 'name': 'minSoilTemp'},
   {'interface': ISequence, 'name': 'maxSoilTemp'},
   {'interface': ISequence, 'name': 'aveSoilTemp'},
   {'interface': ISequence, 'name': 'morningSoilTemp'},
   {'interface': ISequence, 'name': 'newTemperature'},
   {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'maxTempYesterday'},
   {  'interface': IFloat(min=-60, max=60, step=1.000000),
      'name': 'minTempYesterday'},
   {'interface': ISequence, 'name': 'thermalCondPar1'},
   {'interface': ISequence, 'name': 'thermalCondPar2'},
   {'interface': ISequence, 'name': 'thermalCondPar3'},
   {'interface': ISequence, 'name': 'thermalCondPar4'},
   {'interface': ISequence, 'name': 'thermalConductivity'},
   {'interface': ISequence, 'name': 'thermalConductance'},
   {'interface': ISequence, 'name': 'heatStorage'},
   {'interface': ISequence, 'name': 'volSpecHeatSoil'},
   {'interface': IFloat, 'name': '_boundaryLayerConductance'},
   {'interface': ISequence, 'name': 'THICKApsim'},
   {'interface': ISequence, 'name': 'DEPTHApsim'},
   {'interface': ISequence, 'name': 'BDApsim'},
   {'interface': ISequence, 'name': 'SWApsim'},
   {'interface': ISequence, 'name': 'CLAYApsim'},
   {'interface': ISequence, 'name': 'SLROCKApsim'},
   {'interface': ISequence, 'name': 'SLCARBApsim'},
   {'interface': ISequence, 'name': 'SLSANDApsim'},
   {'interface': ISequence, 'name': 'SLSILTApsim'}],
                             elt_factory={2: ('amei.campbell.', 'Campbell')},
                             elt_connections={  4306196624: (2, 0, '__out__', 0),
   4306196656: (2, 1, '__out__', 1),
   4306196688: (2, 2, '__out__', 2),
   4306196720: (2, 3, '__out__', 3),
   4306196752: (2, 4, '__out__', 4),
   4306196784: (2, 5, '__out__', 5),
   4306196816: (2, 6, '__out__', 6),
   4306196848: (2, 7, '__out__', 7),
   4306196880: (2, 8, '__out__', 8),
   4306196912: (2, 9, '__out__', 9),
   4306196944: (2, 10, '__out__', 10),
   4306196976: (2, 11, '__out__', 11),
   4306197008: (2, 12, '__out__', 12),
   4306197040: (2, 13, '__out__', 13),
   4306197072: (2, 14, '__out__', 14),
   4306197104: (2, 15, '__out__', 15),
   4306197136: (2, 16, '__out__', 16),
   4306197168: (2, 17, '__out__', 17),
   4306197200: (2, 18, '__out__', 18),
   4306197232: (2, 19, '__out__', 19),
   4306197264: (2, 20, '__out__', 20),
   4306197296: (2, 21, '__out__', 21),
   4306197328: (2, 22, '__out__', 22),
   4306197360: (2, 23, '__out__', 23),
   4306197392: (2, 24, '__out__', 24),
   4306197424: (2, 25, '__out__', 25),
   4306197456: ('__in__', 0, 2, 0),
   4306197488: ('__in__', 1, 2, 1),
   4306197520: ('__in__', 2, 2, 2),
   4306197552: ('__in__', 3, 2, 3),
   4306197584: ('__in__', 4, 2, 4),
   4306197616: ('__in__', 5, 2, 5),
   4306197648: ('__in__', 6, 2, 6),
   4306197680: ('__in__', 7, 2, 7),
   4306197712: ('__in__', 8, 2, 8),
   4306197744: ('__in__', 9, 2, 9),
   4306197776: ('__in__', 10, 2, 10),
   4306197808: ('__in__', 11, 2, 11),
   4306197840: ('__in__', 12, 2, 12),
   4306197872: ('__in__', 13, 2, 13),
   4306197904: ('__in__', 14, 2, 14),
   4306197936: ('__in__', 15, 2, 15),
   4306197968: ('__in__', 16, 2, 16),
   4306198000: ('__in__', 17, 2, 17),
   4306198032: ('__in__', 18, 2, 18),
   4306198064: ('__in__', 19, 2, 19),
   4306198096: ('__in__', 20, 2, 20),
   4306198128: ('__in__', 21, 2, 21),
   4306198160: ('__in__', 22, 2, 22),
   4306198192: ('__in__', 23, 2, 23),
   4306198224: ('__in__', 24, 2, 24),
   4306198256: ('__in__', 25, 2, 25),
   4306198288: ('__in__', 26, 2, 26),
   4306198320: ('__in__', 27, 2, 27),
   4306198352: ('__in__', 28, 2, 28),
   4306198384: ('__in__', 29, 2, 29),
   4306198416: ('__in__', 30, 2, 30),
   4306198448: ('__in__', 31, 2, 31),
   4306198480: ('__in__', 32, 2, 32),
   4306198512: ('__in__', 33, 2, 33),
   4306198544: ('__in__', 34, 2, 34),
   4306198576: ('__in__', 35, 2, 35),
   4306198608: ('__in__', 36, 2, 36),
   4306198640: ('__in__', 37, 2, 37),
   4306198672: ('__in__', 38, 2, 38),
   4306198704: ('__in__', 39, 2, 39),
   4306198736: ('__in__', 40, 2, 40),
   4306198768: ('__in__', 41, 2, 41),
   4306198800: ('__in__', 42, 2, 42),
   4306198832: ('__in__', 43, 2, 43),
   4306198864: ('__in__', 44, 2, 44),
   4306198896: ('__in__', 45, 2, 45),
   4306198928: ('__in__', 46, 2, 46),
   4306198960: ('__in__', 47, 2, 47),
   4306198992: ('__in__', 48, 2, 48),
   4306199024: ('__in__', 49, 2, 49),
   4306199056: ('__in__', 50, 2, 50),
   4306199088: ('__in__', 51, 2, 51),
   4306199120: ('__in__', 52, 2, 52),
   4306199152: ('__in__', 53, 2, 53)},
                             elt_data={  2: {  'block': False,
         'caption': 'Campbell',
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



