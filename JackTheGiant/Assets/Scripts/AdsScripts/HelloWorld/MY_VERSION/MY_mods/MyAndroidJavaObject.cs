#define TESTING01
// Decompiled with JetBrains decompiler
// Type: UnityEngine.AndroidJavaObject
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8FF7A2C-E4EE-4232-AB17-3FCABEC16496
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEngine.dll

using System;
using System.Text;

namespace UnityEngine
{
  /// <summary>
  ///   <para>AndroidJavaObject is the Unity representation of a generic instance of java.lang.Object.</para>
  /// </summary>
  public class MyAndroidJavaObject : IDisposable
  {
        
        #region declair fields/properties
        #region static fields/properties
        private static bool enableDebugPrints;
        private static MyAndroidJavaClass s_JavaLangClass;
        protected static MyAndroidJavaClass JavaLangClass
        {
            get
            {
                if (MyAndroidJavaObject.s_JavaLangClass == null)
                    MyAndroidJavaObject.s_JavaLangClass = new MyAndroidJavaClass(MyAndroidJNISafe.FindClass("java/lang/Class"));
                return MyAndroidJavaObject.s_JavaLangClass;
            }
        }
        #endregion

        #region instanced fields
        private bool m_disposed;
        protected IntPtr m_jobject;
        protected IntPtr m_jclass;
        #endregion
        #endregion

        #region constructors
        /// <summary>
        ///   <para>Construct an AndroidJavaObject based on the name of the class.</para>
        /// </summary>
        /// <param name="className">Specifies the Java class name (e.g. "&lt;tt&gt;java.lang.String&lt;tt&gt;" or "&lt;tt&gt;javalangString&lt;tt&gt;").</param>
        /// <param name="args">An array of parameters passed to the constructor.</param>
        public MyAndroidJavaObject(string className, params object[] args)
        : this()
        {
            this._AndroidJavaObject(className, args);
        }

        internal MyAndroidJavaObject(IntPtr jobject)
        : this()
        {
            if (jobject == IntPtr.Zero) throw new Exception("JNI: Init'd AndroidJavaObject with null ptr!");
            IntPtr objectClass = MyAndroidJNISafe.GetObjectClass(jobject);
            this.m_jobject = MyAndroidJNI.NewGlobalRef(jobject);
            this.m_jclass = MyAndroidJNI.NewGlobalRef(objectClass);
            MyAndroidJNISafe.DeleteLocalRef(objectClass);
        }

        internal MyAndroidJavaObject(){}

        private void _AndroidJavaObject(string className, params object[] args)
        {
            this.DebugPrint("Creating AndroidJavaObject from " + className);
            if (args == null) args = new object[1];
            using (MyAndroidJavaObject androidJavaObject = MyAndroidJavaObject.FindClass(className))
            {
                this.m_jclass = MyAndroidJNI.NewGlobalRef(androidJavaObject.GetRawObject());
                jvalue[] jniArgArray = AndroidJNIHelper.CreateJNIArgArray(args);
                try
                {
                    IntPtr localref = MyAndroidJNISafe.NewObject(this.m_jclass, AndroidJNIHelper.GetConstructorID(this.m_jclass, args), jniArgArray);
                    this.m_jobject = MyAndroidJNI.NewGlobalRef(localref);
                    MyAndroidJNISafe.DeleteLocalRef(localref);
                }
                finally
                {
                    AndroidJNIHelper.DeleteJNIArgArray(args, jniArgArray);
                }
            }
        }
        #endregion

        #region dispose-methods

        ~MyAndroidJavaObject(){   this.Dispose(true);  }

        /// <summary>
        ///   <para>IDisposable callback.</para>
        /// </summary>
        public void Dispose(){   this._Dispose();   }

        protected virtual void Dispose(bool disposing)
        {
            if (this.m_disposed) return;
            this.m_disposed = true;
            MyAndroidJNISafe.DeleteGlobalRef(this.m_jobject);
            MyAndroidJNISafe.DeleteGlobalRef(this.m_jclass);
        }

        protected void _Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        #endregion

        #region 'access java_code'-methods
        #region 'Call'-methods

        /// <summary>
        ///   <para>Call a Java method on an object.</para>
        /// </summary>
        /// <param name="methodName">Specifies which method to call.</param>
        /// <param name="args">An array of parameters passed to the method.</param>
        public void Call(string methodName, params object[] args)
        {
            this._Call(methodName, args);
        }

        /// <summary>
        ///   <para>Call a static Java method on a class.</para>
        /// </summary>
        /// <param name="methodName">Specifies which method to call.</param>
        /// <param name="args">An array of parameters passed to the method.</param>
        public void CallStatic(string methodName, params object[] args)
        {
            this._CallStatic(methodName, args);
        }

        public ReturnType Call<ReturnType>(string methodName, params object[] args)
        {
            return this._Call<ReturnType>(methodName, args);
        }

        public ReturnType CallStatic<ReturnType>(string methodName, params object[] args)
        {
            return this._CallStatic<ReturnType>(methodName, args);
        }

        protected void _Call(string methodName, params object[] args)
        {
            if (args == null) args = new object[1];
            IntPtr methodId = AndroidJNIHelper.GetMethodID(this.m_jclass, methodName, args, false);
            jvalue[] jniArgArray = AndroidJNIHelper.CreateJNIArgArray(args);
            try
            {
                MyAndroidJNISafe.CallVoidMethod(this.m_jobject, methodId, jniArgArray);
            }
            finally
            {
                AndroidJNIHelper.DeleteJNIArgArray(args, jniArgArray);
            }
        }

        protected ReturnType _Call<ReturnType>(string methodName, params object[] args)
        {
            if (args == null) args = new object[1];
            IntPtr methodId = AndroidJNIHelper.GetMethodID<ReturnType>(this.m_jclass, methodName, args, false);
            jvalue[] jniArgArray = AndroidJNIHelper.CreateJNIArgArray(args);
            try
            {
                #region pass inputs to correct MyAndroidJNISafe static method, and convert output to correct type
                if (MyAndroidReflection.IsPrimitive(typeof(ReturnType)))
                {
                    #region fixed-version
#if TESTING01
                    #region fixed
                    if (typeof(ReturnType) == typeof(int))
                        return (ReturnType)(object)MyAndroidJNISafe.CallIntMethod(this.m_jobject, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(bool))
                        return (ReturnType)(object)MyAndroidJNISafe.CallBooleanMethod(this.m_jobject, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(byte))
                        return (ReturnType)(object)MyAndroidJNISafe.CallByteMethod(this.m_jobject, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(short))
                        return (ReturnType)(object)MyAndroidJNISafe.CallShortMethod(this.m_jobject, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(long))
                        return (ReturnType)(object)MyAndroidJNISafe.CallLongMethod(this.m_jobject, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(float))
                        return (ReturnType)(object)MyAndroidJNISafe.CallFloatMethod(this.m_jobject, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(double))
                        return (ReturnType)(object)MyAndroidJNISafe.CallDoubleMethod(this.m_jobject, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(char))
                        return (ReturnType)(object)MyAndroidJNISafe.CallCharMethod(this.m_jobject, methodId, jniArgArray);
                    return default(ReturnType);
                    #endregion
#else
                    #region original
                    if (typeof (ReturnType) == typeof (int))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallIntMethod(this.m_jobject, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (bool))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallBooleanMethod(this.m_jobject, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (byte))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallByteMethod(this.m_jobject, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (short))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallShortMethod(this.m_jobject, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (long))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallLongMethod(this.m_jobject, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (float))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallFloatMethod(this.m_jobject, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (double))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallDoubleMethod(this.m_jobject, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (char))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallCharMethod(this.m_jobject, methodId, jniArgArray);
          return default (ReturnType);
                    #endregion
#endif
                    #endregion
                }
                #region fixed-version
#if TESTING01
                #region fixed
                if (typeof(ReturnType) == typeof(string))
                    return (ReturnType)(object)MyAndroidJNISafe.CallStringMethod(this.m_jobject, methodId, jniArgArray);
                if (typeof(ReturnType) == typeof(MyAndroidJavaClass))
                    return (ReturnType)(object)MyAndroidJavaObject.AndroidJavaClassDeleteLocalRef(MyAndroidJNISafe.CallObjectMethod(this.m_jobject, methodId, jniArgArray));
                if (typeof(ReturnType) == typeof(MyAndroidJavaObject))
                    return (ReturnType)(object)MyAndroidJavaObject.AndroidJavaObjectDeleteLocalRef(MyAndroidJNISafe.CallObjectMethod(this.m_jobject, methodId, jniArgArray));
                if (MyAndroidReflection.IsAssignableFrom(typeof(Array), typeof(ReturnType)))
                    return AndroidJNIHelper.ConvertFromJNIArray<ReturnType>(MyAndroidJNISafe.CallObjectMethod(this.m_jobject, methodId, jniArgArray));
                #endregion
#else
                #region origional
                if (typeof (ReturnType) == typeof (string))
          return (ReturnType) MyAndroidJNISafe.CallStringMethod(this.m_jobject, methodId, jniArgArray);
        if (typeof (ReturnType) == typeof (MyAndroidJavaClass))
          return (ReturnType) MyAndroidJavaObject.AndroidJavaClassDeleteLocalRef(MyAndroidJNISafe.CallObjectMethod(this.m_jobject, methodId, jniArgArray));
        if (typeof (ReturnType) == typeof (MyAndroidJavaObject))
          return (ReturnType) MyAndroidJavaObject.AndroidJavaObjectDeleteLocalRef(MyAndroidJNISafe.CallObjectMethod(this.m_jobject, methodId, jniArgArray));
        if (MyAndroidReflection.IsAssignableFrom(typeof (Array), typeof (ReturnType)))
          return AndroidJNIHelper.ConvertFromJNIArray<ReturnType>(MyAndroidJNISafe.CallObjectMethod(this.m_jobject, methodId, jniArgArray));
                #endregion
#endif
                #endregion
                throw new Exception("JNI: Unknown return type '" + (object)typeof(ReturnType) + "'");
                #endregion
            }
            finally
            {
                AndroidJNIHelper.DeleteJNIArgArray(args, jniArgArray);
            }
        }

        protected void _CallStatic(string methodName, params object[] args)
        {
            if (args == null) args = new object[1];
            IntPtr methodId = AndroidJNIHelper.GetMethodID(this.m_jclass, methodName, args, true);
            jvalue[] jniArgArray = AndroidJNIHelper.CreateJNIArgArray(args);
            try
            {
                MyAndroidJNISafe.CallStaticVoidMethod(this.m_jclass, methodId, jniArgArray);
            }
            finally
            {
                AndroidJNIHelper.DeleteJNIArgArray(args, jniArgArray);
            }
        }

        protected ReturnType _CallStatic<ReturnType>(string methodName, params object[] args)
        {
            if (args == null) args = new object[1];
            IntPtr methodId = AndroidJNIHelper.GetMethodID<ReturnType>(this.m_jclass, methodName, args, true);
            jvalue[] jniArgArray = AndroidJNIHelper.CreateJNIArgArray(args);
            try
            {
                if (MyAndroidReflection.IsPrimitive(typeof(ReturnType)))
                {
                    #region pass inputs to correct MyAndroidJNISafe static method, and convert output to correct type
#if TESTING01
                    #region fixed
                    if (typeof(ReturnType) == typeof(int))
                        return (ReturnType)(object)MyAndroidJNISafe.CallStaticIntMethod(this.m_jclass, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(bool))
                        return (ReturnType)(object)MyAndroidJNISafe.CallStaticBooleanMethod(this.m_jclass, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(byte))
                        return (ReturnType)(object)MyAndroidJNISafe.CallStaticByteMethod(this.m_jclass, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(short))
                        return (ReturnType)(object)MyAndroidJNISafe.CallStaticShortMethod(this.m_jclass, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(long))
                        return (ReturnType)(object)MyAndroidJNISafe.CallStaticLongMethod(this.m_jclass, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(float))
                        return (ReturnType)(object)MyAndroidJNISafe.CallStaticFloatMethod(this.m_jclass, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(double))
                        return (ReturnType)(object)MyAndroidJNISafe.CallStaticDoubleMethod(this.m_jclass, methodId, jniArgArray);
                    if (typeof(ReturnType) == typeof(char))
                        return (ReturnType)(object)MyAndroidJNISafe.CallStaticCharMethod(this.m_jclass, methodId, jniArgArray);
                    return default(ReturnType);
                }
                if (typeof(ReturnType) == typeof(string))
                    return (ReturnType)(object)MyAndroidJNISafe.CallStaticStringMethod(this.m_jclass, methodId, jniArgArray);
                if (typeof(ReturnType) == typeof(MyAndroidJavaClass))
                    return (ReturnType)(object)MyAndroidJavaObject.AndroidJavaClassDeleteLocalRef(MyAndroidJNISafe.CallStaticObjectMethod(this.m_jclass, methodId, jniArgArray));
                if (typeof(ReturnType) == typeof(MyAndroidJavaObject))
                    return (ReturnType)(object)MyAndroidJavaObject.AndroidJavaObjectDeleteLocalRef(MyAndroidJNISafe.CallStaticObjectMethod(this.m_jclass, methodId, jniArgArray));
                if (MyAndroidReflection.IsAssignableFrom(typeof(Array), typeof(ReturnType)))
                    return AndroidJNIHelper.ConvertFromJNIArray<ReturnType>(MyAndroidJNISafe.CallStaticObjectMethod(this.m_jclass, methodId, jniArgArray));
                throw new Exception("JNI: Unknown return type '" + (object)typeof(ReturnType) + "'");
                #endregion
#else
                #region origional
                    if (typeof (ReturnType) == typeof (int))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallStaticIntMethod(this.m_jclass, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (bool))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallStaticBooleanMethod(this.m_jclass, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (byte))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallStaticByteMethod(this.m_jclass, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (short))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallStaticShortMethod(this.m_jclass, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (long))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallStaticLongMethod(this.m_jclass, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (float))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallStaticFloatMethod(this.m_jclass, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (double))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallStaticDoubleMethod(this.m_jclass, methodId, jniArgArray);
          if (typeof (ReturnType) == typeof (char))
            return (ReturnType) (ValueType) MyAndroidJNISafe.CallStaticCharMethod(this.m_jclass, methodId, jniArgArray);
          return default (ReturnType);
        }
        if (typeof (ReturnType) == typeof (string))
          return (ReturnType) MyAndroidJNISafe.CallStaticStringMethod(this.m_jclass, methodId, jniArgArray);
        if (typeof (ReturnType) == typeof (MyAndroidJavaClass))
          return (ReturnType) MyAndroidJavaObject.AndroidJavaClassDeleteLocalRef(MyAndroidJNISafe.CallStaticObjectMethod(this.m_jclass, methodId, jniArgArray));
        if (typeof (ReturnType) == typeof (MyAndroidJavaObject))
          return (ReturnType) MyAndroidJavaObject.AndroidJavaObjectDeleteLocalRef(MyAndroidJNISafe.CallStaticObjectMethod(this.m_jclass, methodId, jniArgArray));
        if (MyAndroidReflection.IsAssignableFrom(typeof (Array), typeof (ReturnType)))
          return AndroidJNIHelper.ConvertFromJNIArray<ReturnType>(MyAndroidJNISafe.CallStaticObjectMethod(this.m_jclass, methodId, jniArgArray));
        throw new Exception("JNI: Unknown return type '" + (object) typeof (ReturnType) + "'");
                #endregion
#endif
                #endregion
            }
            finally
            {
                AndroidJNIHelper.DeleteJNIArgArray(args, jniArgArray);
            }
        }

        #endregion

        #region 'Get'-methods
        public FieldType Get<FieldType>(string fieldName)
        {
            return this._Get<FieldType>(fieldName);
        }

        public FieldType GetStatic<FieldType>(string fieldName)
        {
            return this._GetStatic<FieldType>(fieldName);
        }

        protected FieldType _Get<FieldType>(string fieldName)
        {
            IntPtr fieldId = AndroidJNIHelper.GetFieldID<FieldType>(this.m_jclass, fieldName, false);

            #region pass inputs to correct MyAndroidJNISafe static method, and convert output to correct type

#if TESTING01
            #region fixed
            if (MyAndroidReflection.IsPrimitive(typeof(FieldType)))
            {
                if (typeof(FieldType) == typeof(int))
                    return (FieldType)(object)MyAndroidJNISafe.GetIntField(this.m_jobject, fieldId);
                if (typeof(FieldType) == typeof(bool))
                    return (FieldType)(object)MyAndroidJNISafe.GetBooleanField(this.m_jobject, fieldId);
                if (typeof(FieldType) == typeof(byte))
                    return (FieldType)(object)MyAndroidJNISafe.GetByteField(this.m_jobject, fieldId);
                if (typeof(FieldType) == typeof(short))
                    return (FieldType)(object)MyAndroidJNISafe.GetShortField(this.m_jobject, fieldId);
                if (typeof(FieldType) == typeof(long))
                    return (FieldType)(object)MyAndroidJNISafe.GetLongField(this.m_jobject, fieldId);
                if (typeof(FieldType) == typeof(float))
                    return (FieldType)(object)MyAndroidJNISafe.GetFloatField(this.m_jobject, fieldId);
                if (typeof(FieldType) == typeof(double))
                    return (FieldType)(object)MyAndroidJNISafe.GetDoubleField(this.m_jobject, fieldId);
                if (typeof(FieldType) == typeof(char))
                    return (FieldType)(object)MyAndroidJNISafe.GetCharField(this.m_jobject, fieldId);
                return default(FieldType);
            }
            if (typeof(FieldType) == typeof(string))
                return (FieldType)(object)MyAndroidJNISafe.GetStringField(this.m_jobject, fieldId);
            if (typeof(FieldType) == typeof(MyAndroidJavaClass))
                return (FieldType)(object)MyAndroidJavaObject.AndroidJavaClassDeleteLocalRef(MyAndroidJNISafe.GetObjectField(this.m_jobject, fieldId));
            if (typeof(FieldType) == typeof(MyAndroidJavaObject))
                return (FieldType)(object)MyAndroidJavaObject.AndroidJavaObjectDeleteLocalRef(MyAndroidJNISafe.GetObjectField(this.m_jobject, fieldId));
            if (MyAndroidReflection.IsAssignableFrom(typeof(Array), typeof(FieldType)))
                return AndroidJNIHelper.ConvertFromJNIArray<FieldType>(MyAndroidJNISafe.GetObjectField(this.m_jobject, fieldId));
            throw new Exception("JNI: Unknown field type '" + (object)typeof(FieldType) + "'");
            #endregion
#else
            #region original
        if (MyAndroidReflection.IsPrimitive(typeof(FieldType)))
        {
                if (typeof (FieldType) == typeof (int))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetIntField(this.m_jobject, fieldId);
        if (typeof (FieldType) == typeof (bool))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetBooleanField(this.m_jobject, fieldId);
        if (typeof (FieldType) == typeof (byte))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetByteField(this.m_jobject, fieldId);
        if (typeof (FieldType) == typeof (short))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetShortField(this.m_jobject, fieldId);
        if (typeof (FieldType) == typeof (long))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetLongField(this.m_jobject, fieldId);
        if (typeof (FieldType) == typeof (float))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetFloatField(this.m_jobject, fieldId);
        if (typeof (FieldType) == typeof (double))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetDoubleField(this.m_jobject, fieldId);
        if (typeof (FieldType) == typeof (char))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetCharField(this.m_jobject, fieldId);
        return default (FieldType);
      }
      if (typeof (FieldType) == typeof (string))
        return (FieldType) MyAndroidJNISafe.GetStringField(this.m_jobject, fieldId);
      if (typeof (FieldType) == typeof (MyAndroidJavaClass))
        return (FieldType) MyAndroidJavaObject.AndroidJavaClassDeleteLocalRef(MyAndroidJNISafe.GetObjectField(this.m_jobject, fieldId));
      if (typeof (FieldType) == typeof (MyAndroidJavaObject))
        return (FieldType) MyAndroidJavaObject.AndroidJavaObjectDeleteLocalRef(MyAndroidJNISafe.GetObjectField(this.m_jobject, fieldId));
      if (MyAndroidReflection.IsAssignableFrom(typeof (Array), typeof (FieldType)))
        return AndroidJNIHelper.ConvertFromJNIArray<FieldType>(MyAndroidJNISafe.GetObjectField(this.m_jobject, fieldId));
      throw new Exception("JNI: Unknown field type '" + (object) typeof (FieldType) + "'");
            #endregion
#endif
            #endregion
        }

        protected FieldType _GetStatic<FieldType>(string fieldName)
        {
            IntPtr fieldId = AndroidJNIHelper.GetFieldID<FieldType>(this.m_jclass, fieldName, true);

            #region pass inputs to correct MyAndroidJNISafe static method, and convert output to correct type
#if TESTING01
            #region fixed
            if (MyAndroidReflection.IsPrimitive(typeof(FieldType)))
            {
                if (typeof(FieldType) == typeof(int))
                    return (FieldType)(object)MyAndroidJNISafe.GetStaticIntField(this.m_jclass, fieldId);
                if (typeof(FieldType) == typeof(bool))
                    return (FieldType)(object)MyAndroidJNISafe.GetStaticBooleanField(this.m_jclass, fieldId);
                if (typeof(FieldType) == typeof(byte))
                    return (FieldType)(object)MyAndroidJNISafe.GetStaticByteField(this.m_jclass, fieldId);
                if (typeof(FieldType) == typeof(short))
                    return (FieldType)(object)MyAndroidJNISafe.GetStaticShortField(this.m_jclass, fieldId);
                if (typeof(FieldType) == typeof(long))
                    return (FieldType)(object)MyAndroidJNISafe.GetStaticLongField(this.m_jclass, fieldId);
                if (typeof(FieldType) == typeof(float))
                    return (FieldType)(object)MyAndroidJNISafe.GetStaticFloatField(this.m_jclass, fieldId);
                if (typeof(FieldType) == typeof(double))
                    return (FieldType)(object)MyAndroidJNISafe.GetStaticDoubleField(this.m_jclass, fieldId);
                if (typeof(FieldType) == typeof(char))
                    return (FieldType)(object)MyAndroidJNISafe.GetStaticCharField(this.m_jclass, fieldId);
                return default(FieldType);
            }
            if (typeof(FieldType) == typeof(string))
                return (FieldType)(object)MyAndroidJNISafe.GetStaticStringField(this.m_jclass, fieldId);
            if (typeof(FieldType) == typeof(MyAndroidJavaClass))
                return (FieldType)(object)MyAndroidJavaObject.AndroidJavaClassDeleteLocalRef(MyAndroidJNISafe.GetStaticObjectField(this.m_jclass, fieldId));
            if (typeof(FieldType) == typeof(MyAndroidJavaObject))
                return (FieldType)(object)MyAndroidJavaObject.AndroidJavaObjectDeleteLocalRef(MyAndroidJNISafe.GetStaticObjectField(this.m_jclass, fieldId));
            if (MyAndroidReflection.IsAssignableFrom(typeof(Array), typeof(FieldType)))
                return AndroidJNIHelper.ConvertFromJNIArray<FieldType>(MyAndroidJNISafe.GetStaticObjectField(this.m_jclass, fieldId));
            throw new Exception("JNI: Unknown field type '" + (object)typeof(FieldType) + "'");
            #endregion
#else
            #region original
        if (MyAndroidReflection.IsPrimitive(typeof(FieldType)))
      {
                if (typeof (FieldType) == typeof (int))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetStaticIntField(this.m_jclass, fieldId);
        if (typeof (FieldType) == typeof (bool))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetStaticBooleanField(this.m_jclass, fieldId);
        if (typeof (FieldType) == typeof (byte))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetStaticByteField(this.m_jclass, fieldId);
        if (typeof (FieldType) == typeof (short))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetStaticShortField(this.m_jclass, fieldId);
        if (typeof (FieldType) == typeof (long))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetStaticLongField(this.m_jclass, fieldId);
        if (typeof (FieldType) == typeof (float))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetStaticFloatField(this.m_jclass, fieldId);
        if (typeof (FieldType) == typeof (double))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetStaticDoubleField(this.m_jclass, fieldId);
        if (typeof (FieldType) == typeof (char))
          return (FieldType) (ValueType) MyAndroidJNISafe.GetStaticCharField(this.m_jclass, fieldId);
        return default (FieldType);
      }
      if (typeof (FieldType) == typeof (string))
        return (FieldType) MyAndroidJNISafe.GetStaticStringField(this.m_jclass, fieldId);
      if (typeof (FieldType) == typeof (MyAndroidJavaClass))
        return (FieldType) MyAndroidJavaObject.AndroidJavaClassDeleteLocalRef(MyAndroidJNISafe.GetStaticObjectField(this.m_jclass, fieldId));
      if (typeof (FieldType) == typeof (MyAndroidJavaObject))
        return (FieldType) MyAndroidJavaObject.AndroidJavaObjectDeleteLocalRef(MyAndroidJNISafe.GetStaticObjectField(this.m_jclass, fieldId));
      if (MyAndroidReflection.IsAssignableFrom(typeof (Array), typeof (FieldType)))
        return AndroidJNIHelper.ConvertFromJNIArray<FieldType>(MyAndroidJNISafe.GetStaticObjectField(this.m_jclass, fieldId));
      throw new Exception("JNI: Unknown field type '" + (object) typeof (FieldType) + "'");
            #endregion
#endif
            #endregion
        }
        
        #endregion

        #region 'Set'-methods
        public void Set<FieldType>(string fieldName, FieldType val)
        {
            this._Set<FieldType>(fieldName, val);
        }
        public void SetStatic<FieldType>(string fieldName, FieldType val)
        {
            this._SetStatic<FieldType>(fieldName, val);
        }
        protected void _Set<FieldType>(string fieldName, FieldType val)
        {
            IntPtr fieldId = AndroidJNIHelper.GetFieldID<FieldType>(this.m_jclass, fieldName, false);
            if (MyAndroidReflection.IsPrimitive(typeof(FieldType)))
            {
                if (typeof(FieldType) == typeof(int))
                    MyAndroidJNISafe.SetIntField(this.m_jobject, fieldId, (int)(object)val);
                else if (typeof(FieldType) == typeof(bool))
                    MyAndroidJNISafe.SetBooleanField(this.m_jobject, fieldId, (bool)(object)val);
                else if (typeof(FieldType) == typeof(byte))
                    MyAndroidJNISafe.SetByteField(this.m_jobject, fieldId, (byte)(object)val);
                else if (typeof(FieldType) == typeof(short))
                    MyAndroidJNISafe.SetShortField(this.m_jobject, fieldId, (short)(object)val);
                else if (typeof(FieldType) == typeof(long))
                    MyAndroidJNISafe.SetLongField(this.m_jobject, fieldId, (long)(object)val);
                else if (typeof(FieldType) == typeof(float))
                    MyAndroidJNISafe.SetFloatField(this.m_jobject, fieldId, (float)(object)val);
                else if (typeof(FieldType) == typeof(double))
                {
                    MyAndroidJNISafe.SetDoubleField(this.m_jobject, fieldId, (double)(object)val);
                }
                else
                {
                    if (typeof(FieldType) != typeof(char)) return;
                    MyAndroidJNISafe.SetCharField(this.m_jobject, fieldId, (char)(object)val);
                }
            }
            else if (typeof(FieldType) == typeof(string))
                MyAndroidJNISafe.SetStringField(this.m_jobject, fieldId, (string)(object)val);
            else if (typeof(FieldType) == typeof(MyAndroidJavaClass))
                MyAndroidJNISafe.SetObjectField(this.m_jobject, fieldId, ((MyAndroidJavaObject)(object)val).m_jclass);
            else if (typeof(FieldType) == typeof(MyAndroidJavaObject))
            {
                MyAndroidJNISafe.SetObjectField(this.m_jobject, fieldId, ((MyAndroidJavaObject)(object)val).m_jobject);
            }
            else
            {
                if (!MyAndroidReflection.IsAssignableFrom(typeof(Array), typeof(FieldType)))
                    throw new Exception("JNI: Unknown field type '" + (object)typeof(FieldType) + "'");
                IntPtr jniArray = AndroidJNIHelper.ConvertToJNIArray((Array)(object)val);
                MyAndroidJNISafe.SetObjectField(this.m_jclass, fieldId, jniArray);
            }
        }
        protected void _SetStatic<FieldType>(string fieldName, FieldType val)
        {
            IntPtr fieldId = AndroidJNIHelper.GetFieldID<FieldType>(this.m_jclass, fieldName, true);
            if (MyAndroidReflection.IsPrimitive(typeof(FieldType)))
            {
                if (typeof(FieldType) == typeof(int))
                    MyAndroidJNISafe.SetStaticIntField(this.m_jclass, fieldId, (int)(object)val);
                else if (typeof(FieldType) == typeof(bool))
                    MyAndroidJNISafe.SetStaticBooleanField(this.m_jclass, fieldId, (bool)(object)val);
                else if (typeof(FieldType) == typeof(byte))
                    MyAndroidJNISafe.SetStaticByteField(this.m_jclass, fieldId, (byte)(object)val);
                else if (typeof(FieldType) == typeof(short))
                    MyAndroidJNISafe.SetStaticShortField(this.m_jclass, fieldId, (short)(object)val);
                else if (typeof(FieldType) == typeof(long))
                    MyAndroidJNISafe.SetStaticLongField(this.m_jclass, fieldId, (long)(object)val);
                else if (typeof(FieldType) == typeof(float))
                    MyAndroidJNISafe.SetStaticFloatField(this.m_jclass, fieldId, (float)(object)val);
                else if (typeof(FieldType) == typeof(double))
                {
                    MyAndroidJNISafe.SetStaticDoubleField(this.m_jclass, fieldId, (double)(object)val);
                }
                else
                {
                    if (typeof(FieldType) != typeof(char)) return;
                    MyAndroidJNISafe.SetStaticCharField(this.m_jclass, fieldId, (char)(object)val);
                }
            }
            else if (typeof(FieldType) == typeof(string))
                MyAndroidJNISafe.SetStaticStringField(this.m_jclass, fieldId, (string)(object)val);
            else if (typeof(FieldType) == typeof(MyAndroidJavaClass))
                MyAndroidJNISafe.SetStaticObjectField(this.m_jclass, fieldId, ((MyAndroidJavaObject)(object)val).m_jclass);
            else if (typeof(FieldType) == typeof(MyAndroidJavaObject))
            {
                MyAndroidJNISafe.SetStaticObjectField(this.m_jclass, fieldId, ((MyAndroidJavaObject)(object)val).m_jobject);
            }
            else
            {
                if (!MyAndroidReflection.IsAssignableFrom(typeof(Array), typeof(FieldType)))
                    throw new Exception("JNI: Unknown field type '" + (object)typeof(FieldType) + "'");
                IntPtr jniArray = AndroidJNIHelper.ConvertToJNIArray((Array)(object)val);
                MyAndroidJNISafe.SetStaticObjectField(this.m_jclass, fieldId, jniArray);
            }
        }
        #endregion

        #region 'GetRaw'-methods
        /// <summary>
        ///   <para>Retrieve the raw jobject pointer to the Java object.</para>
        /// </summary>
        public IntPtr GetRawObject()
        {
            return this._GetRawObject();
        }

        /// <summary>
        ///   <para>Retrieve the raw jclass pointer to the Java class.</para>
        /// </summary>
        public IntPtr GetRawClass()
        {
            return this._GetRawClass();
        }

        protected IntPtr _GetRawObject()
        {
            return this.m_jobject;
        }

        protected IntPtr _GetRawClass()
        {
            return this.m_jclass;
        }

        #endregion
        #endregion

        #region DebugPrint-methods
        protected void DebugPrint(string msg)
        {
            if (!MyAndroidJavaObject.enableDebugPrints) return;
            Debug.Log((object) msg);
        }

        protected void DebugPrint(string call, string methodName, string signature, object[] args)
        {
            if (!MyAndroidJavaObject.enableDebugPrints) return;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (object obj in args)
            {
                stringBuilder.Append(", ");
                stringBuilder.Append(obj != null ? obj.GetType().ToString() : "<null>");
            }
            Debug.Log((object) (call + "(\"" + methodName + "\"" + stringBuilder.ToString() + ") = " + signature));
        }
        #endregion
        
        #region other (includes 'FindClass')

        internal static MyAndroidJavaObject AndroidJavaObjectDeleteLocalRef(IntPtr jobject)
        {
            try
            {
                return new MyAndroidJavaObject(jobject);
            }
            finally
            {
                MyAndroidJNISafe.DeleteLocalRef(jobject);
            }
        }

        internal static MyAndroidJavaClass AndroidJavaClassDeleteLocalRef(IntPtr jclass)
        {
            try
            {
                return new MyAndroidJavaClass(jclass);
            }
            finally
            {
                MyAndroidJNISafe.DeleteLocalRef(jclass);
            }
        }
        
        protected static MyAndroidJavaObject FindClass(string name)
        {
            return MyAndroidJavaObject.JavaLangClass.CallStatic<MyAndroidJavaObject>("forName", new object[1]{ (object) name.Replace('/', '.') });
        }

        #endregion
    }
}