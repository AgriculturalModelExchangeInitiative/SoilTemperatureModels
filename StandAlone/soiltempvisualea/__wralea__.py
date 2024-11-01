################################################################################


__doc__ = """ AMEI Soil Temperature """
__license__ = "Cecill-C"
__revision__ = "  "

from openalea.core import Factory as Fa

__name__ = "amei.soil temperature"

__version__ = '0.0.1'
__license__ = "Cecill-C"
__authors__ = 'AMEI Consortium'
__institutes__ = 'INRIA/CIRAD/INRAE'
__description__ = 'Nodes for soil temperature models creation, edition and visualisation.'
__url__ = 'http://openalea.rtfd.io'

__all__ = []

config_ = Fa(name="config",
            description="configuration for simulation",
            category="soil",
            nodemodule="configuration",
            nodeclass="Configuration",
            )

__all__.append('config_')

models_ = Fa(name="Models",
            description="Soil Temperature models",
            category="soil",
            nodemodule="configuration",
            nodeclass="Models",
            )

__all__.append('models_')

layers_ = Fa(name="columns",
            nodemodule="configuration",
            nodeclass='Columns'
             )
__all__.append('layers_')