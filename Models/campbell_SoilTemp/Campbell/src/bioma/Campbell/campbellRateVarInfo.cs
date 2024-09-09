
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace campbell.DomainClass
                                {
                                    public class campbellRateVarInfo : IVarInfoClass
                                    {

                                        static campbellRateVarInfo()
                                        {
                                            campbellRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "campbellRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "campbellRate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }