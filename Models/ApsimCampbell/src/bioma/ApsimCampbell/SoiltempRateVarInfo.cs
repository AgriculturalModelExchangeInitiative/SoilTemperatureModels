
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Soiltemp.DomainClass
                                {
                                    public class SoiltempRateVarInfo : IVarInfoClass
                                    {

                                        static SoiltempRateVarInfo()
                                        {
                                            SoiltempRateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "SoiltempRate Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "SoiltempRate";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }