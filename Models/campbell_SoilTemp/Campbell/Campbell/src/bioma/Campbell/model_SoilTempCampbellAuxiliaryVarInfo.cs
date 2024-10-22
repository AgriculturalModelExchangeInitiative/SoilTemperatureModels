
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace model_SoilTempCampbell.DomainClass
                                {
                                    public class model_SoilTempCampbellAuxiliaryVarInfo : IVarInfoClass
                                    {

                                        static model_SoilTempCampbellAuxiliaryVarInfo()
                                        {
                                            model_SoilTempCampbellAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "model_SoilTempCampbellAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "model_SoilTempCampbellAuxiliary";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }