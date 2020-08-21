﻿namespace Clock.Xamarin
{
    using System;
    using global::IoC;
    using global::Xamarin.Forms;
    using IoC;

    internal class DataProvider
    {
        private readonly IContainer _container =
            (Application.Current as App)?.Container
            // Resolves from Design Time Container
            ?? Container.Create().Using<ClockDesignTimeConfiguration>();

        private Type _objectType;

        public string ObjectType
        {
            set => _objectType = value != null ? Type.GetType(value, true) : typeof(object);
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public object Tag { get; set; }

        public object It => _container.Resolve<object>(_objectType, Tag);
    }
}
