﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<TParameters> : IFilter where TParameters : IParameters , new ()
    {
        public ParameterInfo[] GetParameters()
        {
            return new  TParameters().GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = new TParameters();
            parameters.Parse(values);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, TParameters parameters);
    }
}
