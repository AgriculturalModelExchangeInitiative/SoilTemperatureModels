###########################################################
### ipython test for debugging transpilation to Crop2ML ###
###########################################################

# in terminal :
# ipython
# %pdb on
# %run test.py
# then print any variable
# and navigate with 'up' and 'down'

from pycropml.transpiler.antlr_py.python.run import *

# Name of the file to debug
fns= """
Campbell/campbell.py
Campbell/Campbell_Component.py
""".split()


files = dict()
for fn in fns:
    files[fn]=fn

mu_names = []
package = '.'
for  k, v in files.items():
    with open(v, "r") as f:
                code = f.read()
    #print(code)

    py_units = extraction(code,modeltag_begin,modeltag_end)
    print (py_units)

    py_inits = extraction(code,inittag_begin,inittag_end)
    file_dictasg = to_dictASG(code, 'py')
    file_asg = to_CASG(file_dictasg)
    z = PythonExtraction()

    if py_inits and len(py_inits)!=len(py_units):
        raise NotAuthorizedException("many init functions in the same module")

    if py_units:
        for py_unit in py_units:
            # match def ...() # retrieve the name
            name = re.findall(r'(def\s+.+\()', py_unit)[0].replace("def", "").replace("(", "").strip()
            
            # extract algorithm of each py_unit using file_asg, the name of the unit
            meth = z.getmethod(file_asg, name, True)

            mdata = extract(meth.doc) # create a ModelUnit object (description, inputs and outputs). After we complete with other info
            #print(mdata.description.ExtendedDescription, "babfsdvhsdbvjsbvbsjvjskdfbv")

            inout = list({var.name for var in mdata.inputs + mdata.outputs}) # extract model in/out

            # finally we got the algo
            algo = translate(inout, meth)
            
            # save algo
            if name.startswith("model_"): name = name.replace("model_", "")
            mu_names.append(mdata.name)
            
            out_compute = os.path.join(package,  "crop2ml", "algo", "pyx", mdata.name + ".pyx")
            with open(out_compute, "w") as fi:
                fi.write(algo + '\n')
            
            #extract external function used in model unit
            extfunc = z.externFunction(file_asg, meth, True)
            # save external functions
            for ext in extfunc:
                name = ext.name
                mdata.function.append(name)
                r = [ext]
                # find all external dependencies of external functions
                while True:
                    ext = ext if  isinstance(ext, list) else [ext]
                    ex = [z.externFunction(file_asg, m, True, m.name) for m in ext ][0]
                    if ex:
                        r.append(ex)
                        ext = ex
                    else:
                        break
                extcode = writeCyml(r)
                exfunc = os.path.join(package, "crop2ml", "algo", "pyx", name + ".pyx")
                with open(exfunc, "w") as fi:
                    fi.write(extcode + '\n')
