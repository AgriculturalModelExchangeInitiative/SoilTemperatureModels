
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityModel_SoilTempCampbell.DomainClass
                                {
                                    public class Model_SoilTempCampbellRateVarInfo : IVarInfoClass
                                    {

                                        static Model_SoilTempCampbellRateVarInfo()
                                        {
                                            Model_SoilTempCampbellRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "Model_SoilTempCampbellRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "Model_SoilTempCampbellRate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }