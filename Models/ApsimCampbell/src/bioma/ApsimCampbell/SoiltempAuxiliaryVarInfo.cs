
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Soiltemp.DomainClass
                                {
                                    public class SoiltempAuxiliaryVarInfo : IVarInfoClass
                                    {

                                        static SoiltempAuxiliaryVarInfo()
                                        {
                                            SoiltempAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "SoiltempAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "SoiltempAuxiliary";}
                                        }

                                        static void DescribeVariables()
                                        {
                                        }

                                    }
                                }