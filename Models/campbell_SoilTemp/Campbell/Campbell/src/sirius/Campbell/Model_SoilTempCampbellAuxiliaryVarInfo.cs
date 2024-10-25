
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityModel_SoilTempCampbell.DomainClass
                                {
                                    public class Model_SoilTempCampbellAuxiliaryVarInfo : IVarInfoClass
                                    {

                                        static Model_SoilTempCampbellAuxiliaryVarInfo()
                                        {
                                            Model_SoilTempCampbellAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "Model_SoilTempCampbellAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "Model_SoilTempCampbellAuxiliary";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }