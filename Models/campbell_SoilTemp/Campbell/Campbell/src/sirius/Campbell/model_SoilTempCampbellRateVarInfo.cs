
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitymodel_SoilTempCampbell.DomainClass
                                {
                                    public class model_SoilTempCampbellRateVarInfo : IVarInfoClass
                                    {

                                        static model_SoilTempCampbellRateVarInfo()
                                        {
                                            model_SoilTempCampbellRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "model_SoilTempCampbellRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "model_SoilTempCampbellRate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }