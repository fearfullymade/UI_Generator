﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EmptyKeys.UserInterface.Generator.Types.Controls
{
    /// <summary>
    /// Implements generator for WrapPanel control
    /// </summary>
    public class WrapPanelGeneratorType : PanelGeneratorType
    {
        /// <summary>
        /// Gets the type of the xaml.
        /// </summary>
        /// <value>
        /// The type of the xaml.
        /// </value>
        public override Type XamlType
        {
            get { return typeof(WrapPanel); }
        }

        /// <summary>
        /// Generates the specified initialize method.
        /// </summary>
        /// <param name="source">The dependency object</param>
        /// <param name="classType">Type of the class.</param>
        /// <param name="initMethod">The initialize method.</param>
        /// <param name="generateField">if set to <c>true</c> [generate field].</param>
        /// <returns></returns>
        public override CodeExpression Generate(DependencyObject source, CodeTypeDeclaration classType, CodeMemberMethod initMethod, bool generateField)
        {
            CodeExpression fieldReference = base.Generate(source, classType, initMethod, generateField);

            WrapPanel wrapPanel = source as WrapPanel;
            CodeComHelper.GenerateFieldDoubleToFloat(initMethod, fieldReference, source, WrapPanel.ItemHeightProperty);
            CodeComHelper.GenerateFieldDoubleToFloat(initMethod, fieldReference, source, WrapPanel.ItemWidthProperty);
            CodeComHelper.GenerateEnumField<Orientation>(initMethod, fieldReference, source, WrapPanel.OrientationProperty);

            return fieldReference;
        } 
    }
}
