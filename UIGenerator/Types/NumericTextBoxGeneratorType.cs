﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmptyKeys.UserInterface.Designer;

namespace EmptyKeys.UserInterface.Generator.Types
{
    /// <summary>
    /// Implements type generator for Numeric Text Box control
    /// </summary>
    public class NumericTextBoxGeneratorType : TextBoxGeneratorType
    {
        /// <summary>
        /// Gets the type of the xaml.
        /// </summary>
        /// <value>
        /// The type of the xaml.
        /// </value>
        public override Type XamlType
        {
            get
            {
                return typeof(NumericTextBox);
            }
        }

        /// <summary>
        /// Generates code
        /// </summary>
        /// <param name="source">The dependence object</param>
        /// <param name="classType">Type of the class.</param>
        /// <param name="initMethod">The initialize method.</param>
        /// <param name="generateField">if set to <c>true</c> [generate field].</param>
        /// <returns></returns>
        public override CodeExpression Generate(DependencyObject source, CodeTypeDeclaration classType, CodeMemberMethod initMethod, bool generateField)
        {
            CodeExpression fieldReference = base.Generate(source, classType, initMethod, generateField);

            NumericTextBox numeric = source as NumericTextBox;
            CodeComHelper.GenerateField<float>(initMethod, fieldReference, source, NumericTextBox.ValueProperty);
            CodeComHelper.GenerateField<float>(initMethod, fieldReference, source, NumericTextBox.MinimumProperty);
            CodeComHelper.GenerateField<float>(initMethod, fieldReference, source, NumericTextBox.MaximumProperty);
            CodeComHelper.GenerateField<float>(initMethod, fieldReference, source, NumericTextBox.IncrementProperty);
            CodeComHelper.GenerateField<string>(initMethod, fieldReference, source, NumericTextBox.ValueFormatProperty);
            CodeComHelper.GenerateFlagEnumField<NumberStyles>(initMethod, fieldReference, source, NumericTextBox.ValueStyleProperty);

            return fieldReference;
        }
    }
}
