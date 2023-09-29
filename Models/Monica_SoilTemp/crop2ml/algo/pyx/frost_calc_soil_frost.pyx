def get_mean_bulk_density():
    cdef float bulk_density_accu
    bulk_density_accu = 0.0
    for i in range(number_of_soil_layers):
        bulk_density_accu += soil_bulk_density[i]

    return bulk_density_accu / float(number_of_soil_layers) / 1000.0  # [Mg m-3]

def get_mean_field_capacity():
  cdef float mean_field_capacity_accu
  mean_field_capacity_accu= 0.0
  for i in range(number_of_soil_layers):
    mean_field_capacity_accu += field_capacity[i]
  return mean_field_capacity_accu / float(number_of_soil_layers)

def calc_sii(mean_field_capacity):
  # @TODO Parameters to be supplied from outside
  cdef float pt_F1
  pt_F1 = 13.05  # Hansson et al. 2004
  cdef float pt_F2
  pt_F2 = 1.06  # Hansson et al. 2004
  return (mean_field_capacity + (1.0 + (pt_F1 * pow(mean_field_capacity, pt_F2)) * mean_field_capacity)) * 100.0

def calc_heat_conductivity_frozen(mean_bulk_density, sii):
    #(((3.0 * mean_bulk_density - 1.7) * 0.001)
    # / (1.0 + (11.5 - 5.0 * mean_bulk_density)
    #    * exp((-50.0) * pow((sii / mean_bulk_density), 1.5))))  # [cal cm-1 K-1 s-1]
    #*86400.0 * double(pt_TimeStep)  # [cal cm-1 K-1 d-1]
    #*4.184 /  # [J cm-1 K-1 d-1]
    #1000000.0 * 100  # [MJ m-1 K-1 d-1]
  return (((3.0 * mean_bulk_density - 1.7) * 0.001)
          / (1.0 + (11.5 - 5.0 * mean_bulk_density)
          * exp((-50.0) * pow((sii / mean_bulk_density), 1.5)))) * 86400.0 * float(time_step) * 4.184 / 1000000.0 * 100

def calc_heat_conductivity_unfrozen(mean_bulk_density, mean_field_capacity):
    #double cond_unfrozen = ((3.0 * mean_bulk_density - 1.7) * 0.001) / (1.0 + (11.5 - 5.0
    #* mean_bulk_density) * exp((-50.0) * pow(((mean_field_capacity * 100.0) / mean_bulk_density), 1.5)))
    #* double(pt_TimeStep) * // [cal cm-1 K-1 s-1]
    #4.184 * // [J cm-1 K-1 s-1]
    #100.0; // [W m-1 K-1]
    return (((3.0 * mean_bulk_density - 1.7) * 0.001)
            / (1.0 + (11.5 - 5.0 * mean_bulk_density)
            * exp((-50.0) * pow(((mean_field_capacity * 100.0) / mean_bulk_density), 1.5))))
        * float(time_step) * 4.184 * 100.0

def calc_temperature_under_snow(mean_air_temperature, snow_depth):
  cdef float temperature_under_snow
  temperature_under_snow = 0.0
  if snow_depth / 100.0 < 0.01 or frost_depth < 0.01:
    temperature_under_snow = mean_air_temperature
  else:
    temperature_under_snow = mean_air_temperature / (1.0 + (10.0 * snow_depth / 100.0) / frost_depth
  return temperature_under_snow

# calculation of mean values
cdef double mean_field_capacity
mean_field_capacity = get_mean_field_capacity()
cdef double mean_bulk_density
mean_bulk_density = get_mean_bulk_density()

# heat conductivity for frozen and unfrozen soil
cdef float sii
sii = calc_sii(mean_field_capacity)
cdef float heat_conductivity_frozen
heat_conductivity_frozen = calc_heat_conductivity_frozen(mean_bulk_density, sii)
cdef float heat_conductivity_unfrozen
heat_conductivity_unfrozen = calc_heat_conductivity_unfrozen(mean_bulk_density, mean_field_capacity)

# temperature under snow
vm_TemperatureUnderSnow = calc_temperature_under_snow(mean_air_temperature, snow_depth)

# frost depth
frost_depth = calcFrostDepth(mean_field_capacity, heat_conductivity_frozen, vm_TemperatureUnderSnow)
vm_accumulatedFrostDepth += frost_depth

# thaw depth
#vm_ThawDepth = calcThawDepth(vm_TemperatureUnderSnow, heat_conductivity_unfrozen, mean_field_capacity)

updateLambdaRedux()
