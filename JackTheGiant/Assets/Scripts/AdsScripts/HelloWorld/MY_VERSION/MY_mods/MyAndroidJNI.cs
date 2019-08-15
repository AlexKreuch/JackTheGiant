#define WRAPPER
// Decompiled with JetBrains decompiler
// Type: UnityEngine.AndroidJNI
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8FF7A2C-E4EE-4232-AB17-3FCABEC16496
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEngine.dll

using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
   
    /// <summary>
    ///   <para>'Raw' JNI interface to Android Dalvik (Java) VM from Mono (CS/JS).</para>
    /// </summary>
    public sealed class MyAndroidJNI
    {

        
        private MyAndroidJNI(){}

#if WRAPPER
        #region pass methods to normal AndroidJNI-implimentations
        public static Int32 AttachCurrentThread(){ return AndroidJNI.AttachCurrentThread(); } 
public static Int32 DetachCurrentThread(){ return AndroidJNI.DetachCurrentThread(); } 
public static Int32 GetVersion(){ return AndroidJNI.GetVersion(); } 
public static IntPtr FindClass(String name){ return AndroidJNI.FindClass(name); } 
public static IntPtr FromReflectedMethod(IntPtr refMethod){ return AndroidJNI.FromReflectedMethod(refMethod); } 
public static IntPtr FromReflectedField(IntPtr refField){ return AndroidJNI.FromReflectedField(refField); } 
public static IntPtr ToReflectedMethod(IntPtr clazz, IntPtr methodID, Boolean isStatic){ return AndroidJNI.ToReflectedMethod(clazz, methodID, isStatic); } 
public static IntPtr ToReflectedField(IntPtr clazz, IntPtr fieldID, Boolean isStatic){ return AndroidJNI.ToReflectedField(clazz, fieldID, isStatic); } 
public static IntPtr GetSuperclass(IntPtr clazz){ return AndroidJNI.GetSuperclass(clazz); } 
public static Boolean IsAssignableFrom(IntPtr clazz1, IntPtr clazz2){ return AndroidJNI.IsAssignableFrom(clazz1, clazz2); } 
public static Int32 Throw(IntPtr obj){ return AndroidJNI.Throw(obj); } 
public static Int32 ThrowNew(IntPtr clazz, String message){ return AndroidJNI.ThrowNew(clazz, message); } 
public static IntPtr ExceptionOccurred(){ return AndroidJNI.ExceptionOccurred(); } 
public static void ExceptionDescribe(){ AndroidJNI.ExceptionDescribe(); } 
public static void ExceptionClear(){ AndroidJNI.ExceptionClear(); } 
public static void FatalError(String message){ AndroidJNI.FatalError(message); } 
public static Int32 PushLocalFrame(Int32 capacity){ return AndroidJNI.PushLocalFrame(capacity); } 
public static IntPtr PopLocalFrame(IntPtr ptr){ return AndroidJNI.PopLocalFrame(ptr); } 
public static IntPtr NewGlobalRef(IntPtr obj){ return AndroidJNI.NewGlobalRef(obj); } 
public static void DeleteGlobalRef(IntPtr obj){ AndroidJNI.DeleteGlobalRef(obj); } 
public static IntPtr NewLocalRef(IntPtr obj){ return AndroidJNI.NewLocalRef(obj); } 
public static void DeleteLocalRef(IntPtr obj){ AndroidJNI.DeleteLocalRef(obj); } 
public static Boolean IsSameObject(IntPtr obj1, IntPtr obj2){ return AndroidJNI.IsSameObject(obj1, obj2); } 
public static Int32 EnsureLocalCapacity(Int32 capacity){ return AndroidJNI.EnsureLocalCapacity(capacity); } 
public static IntPtr AllocObject(IntPtr clazz){ return AndroidJNI.AllocObject(clazz); } 
public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.NewObject(clazz, methodID, args); } 
public static IntPtr GetObjectClass(IntPtr obj){ return AndroidJNI.GetObjectClass(obj); } 
public static Boolean IsInstanceOf(IntPtr obj, IntPtr clazz){ return AndroidJNI.IsInstanceOf(obj, clazz); } 
public static IntPtr GetMethodID(IntPtr clazz, String name, String sig){ return AndroidJNI.GetMethodID(clazz, name, sig); } 
public static IntPtr GetFieldID(IntPtr clazz, String name, String sig){ return AndroidJNI.GetFieldID(clazz, name, sig); } 
public static IntPtr GetStaticMethodID(IntPtr clazz, String name, String sig){ return AndroidJNI.GetStaticMethodID(clazz, name, sig); } 
public static IntPtr GetStaticFieldID(IntPtr clazz, String name, String sig){ return AndroidJNI.GetStaticFieldID(clazz, name, sig); } 
public static IntPtr NewStringUTF(String bytes){ return AndroidJNI.NewStringUTF(bytes); } 
public static Int32 GetStringUTFLength(IntPtr str){ return AndroidJNI.GetStringUTFLength(str); } 
public static String GetStringUTFChars(IntPtr str){ return AndroidJNI.GetStringUTFChars(str); } 
public static String CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStringMethod(obj, methodID, args); } 
public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallObjectMethod(obj, methodID, args); } 
public static Int32 CallIntMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallIntMethod(obj, methodID, args); } 
public static Boolean CallBooleanMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallBooleanMethod(obj, methodID, args); } 
public static Int16 CallShortMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallShortMethod(obj, methodID, args); } 
public static Byte CallByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallByteMethod(obj, methodID, args); } 
public static SByte CallSByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallSByteMethod(obj, methodID, args); } 
public static Char CallCharMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallCharMethod(obj, methodID, args); } 
public static Single CallFloatMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallFloatMethod(obj, methodID, args); } 
public static Double CallDoubleMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallDoubleMethod(obj, methodID, args); } 
public static Int64 CallLongMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallLongMethod(obj, methodID, args); } 
public static void CallVoidMethod(IntPtr obj, IntPtr methodID, jvalue[] args){ AndroidJNI.CallVoidMethod(obj, methodID, args); } 
public static String GetStringField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetStringField(obj, fieldID); } 
public static IntPtr GetObjectField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetObjectField(obj, fieldID); } 
public static Boolean GetBooleanField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetBooleanField(obj, fieldID); } 
public static Byte GetByteField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetByteField(obj, fieldID); } 
public static SByte GetSByteField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetSByteField(obj, fieldID); } 
public static Char GetCharField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetCharField(obj, fieldID); } 
public static Int16 GetShortField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetShortField(obj, fieldID); } 
public static Int32 GetIntField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetIntField(obj, fieldID); } 
public static Int64 GetLongField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetLongField(obj, fieldID); } 
public static Single GetFloatField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetFloatField(obj, fieldID); } 
public static Double GetDoubleField(IntPtr obj, IntPtr fieldID){ return AndroidJNI.GetDoubleField(obj, fieldID); } 
public static void SetStringField(IntPtr obj, IntPtr fieldID, String val){ AndroidJNI.SetStringField(obj, fieldID, val); } 
public static void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr val){ AndroidJNI.SetObjectField(obj, fieldID, val); } 
public static void SetBooleanField(IntPtr obj, IntPtr fieldID, Boolean val){ AndroidJNI.SetBooleanField(obj, fieldID, val); } 
public static void SetByteField(IntPtr obj, IntPtr fieldID, Byte val){ AndroidJNI.SetByteField(obj, fieldID, val); } 
public static void SetSByteField(IntPtr obj, IntPtr fieldID, SByte val){ AndroidJNI.SetSByteField(obj, fieldID, val); } 
public static void SetCharField(IntPtr obj, IntPtr fieldID, Char val){ AndroidJNI.SetCharField(obj, fieldID, val); } 
public static void SetShortField(IntPtr obj, IntPtr fieldID, Int16 val){ AndroidJNI.SetShortField(obj, fieldID, val); } 
public static void SetIntField(IntPtr obj, IntPtr fieldID, Int32 val){ AndroidJNI.SetIntField(obj, fieldID, val); } 
public static void SetLongField(IntPtr obj, IntPtr fieldID, Int64 val){ AndroidJNI.SetLongField(obj, fieldID, val); } 
public static void SetFloatField(IntPtr obj, IntPtr fieldID, Single val){ AndroidJNI.SetFloatField(obj, fieldID, val); } 
public static void SetDoubleField(IntPtr obj, IntPtr fieldID, Double val){ AndroidJNI.SetDoubleField(obj, fieldID, val); } 
public static String CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticStringMethod(clazz, methodID, args); } 
public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticObjectMethod(clazz, methodID, args); } 
public static Int32 CallStaticIntMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticIntMethod(clazz, methodID, args); } 
public static Boolean CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticBooleanMethod(clazz, methodID, args); } 
public static Int16 CallStaticShortMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticShortMethod(clazz, methodID, args); } 
public static Byte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticByteMethod(clazz, methodID, args); } 
public static SByte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticSByteMethod(clazz, methodID, args); } 
public static Char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticCharMethod(clazz, methodID, args); } 
public static Single CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticFloatMethod(clazz, methodID, args); } 
public static Double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticDoubleMethod(clazz, methodID, args); } 
public static Int64 CallStaticLongMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ return AndroidJNI.CallStaticLongMethod(clazz, methodID, args); } 
public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, jvalue[] args){ AndroidJNI.CallStaticVoidMethod(clazz, methodID, args); } 
public static String GetStaticStringField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticStringField(clazz, fieldID); } 
public static IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticObjectField(clazz, fieldID); } 
public static Boolean GetStaticBooleanField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticBooleanField(clazz, fieldID); } 
public static Byte GetStaticByteField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticByteField(clazz, fieldID); } 
public static SByte GetStaticSByteField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticSByteField(clazz, fieldID); } 
public static Char GetStaticCharField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticCharField(clazz, fieldID); } 
public static Int16 GetStaticShortField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticShortField(clazz, fieldID); } 
public static Int32 GetStaticIntField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticIntField(clazz, fieldID); } 
public static Int64 GetStaticLongField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticLongField(clazz, fieldID); } 
public static Single GetStaticFloatField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticFloatField(clazz, fieldID); } 
public static Double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID){ return AndroidJNI.GetStaticDoubleField(clazz, fieldID); } 
public static void SetStaticStringField(IntPtr clazz, IntPtr fieldID, String val){ AndroidJNI.SetStaticStringField(clazz, fieldID, val); } 
public static void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr val){ AndroidJNI.SetStaticObjectField(clazz, fieldID, val); } 
public static void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, Boolean val){ AndroidJNI.SetStaticBooleanField(clazz, fieldID, val); } 
public static void SetStaticByteField(IntPtr clazz, IntPtr fieldID, Byte val){ AndroidJNI.SetStaticByteField(clazz, fieldID, val); } 
public static void SetStaticSByteField(IntPtr clazz, IntPtr fieldID, SByte val){ AndroidJNI.SetStaticSByteField(clazz, fieldID, val); } 
public static void SetStaticCharField(IntPtr clazz, IntPtr fieldID, Char val){ AndroidJNI.SetStaticCharField(clazz, fieldID, val); } 
public static void SetStaticShortField(IntPtr clazz, IntPtr fieldID, Int16 val){ AndroidJNI.SetStaticShortField(clazz, fieldID, val); } 
public static void SetStaticIntField(IntPtr clazz, IntPtr fieldID, Int32 val){ AndroidJNI.SetStaticIntField(clazz, fieldID, val); } 
public static void SetStaticLongField(IntPtr clazz, IntPtr fieldID, Int64 val){ AndroidJNI.SetStaticLongField(clazz, fieldID, val); } 
public static void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, Single val){ AndroidJNI.SetStaticFloatField(clazz, fieldID, val); } 
public static void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, Double val){ AndroidJNI.SetStaticDoubleField(clazz, fieldID, val); } 
public static IntPtr ToBooleanArray(Boolean[] array){ return AndroidJNI.ToBooleanArray(array); } 
public static IntPtr ToByteArray(Byte[] array){ return AndroidJNI.ToByteArray(array); } 
public static IntPtr ToSByteArray(SByte[] array){ return AndroidJNI.ToSByteArray(array); } 
public static IntPtr ToCharArray(Char[] array){ return AndroidJNI.ToCharArray(array); } 
public static IntPtr ToShortArray(Int16[] array){ return AndroidJNI.ToShortArray(array); } 
public static IntPtr ToIntArray(Int32[] array){ return AndroidJNI.ToIntArray(array); } 
public static IntPtr ToLongArray(Int64[] array){ return AndroidJNI.ToLongArray(array); } 
public static IntPtr ToFloatArray(Single[] array){ return AndroidJNI.ToFloatArray(array); } 
public static IntPtr ToDoubleArray(Double[] array){ return AndroidJNI.ToDoubleArray(array); } 
public static IntPtr ToObjectArray(IntPtr[] array, IntPtr arrayClass){ return AndroidJNI.ToObjectArray(array, arrayClass); } 
public static IntPtr ToObjectArray(IntPtr[] array){ return AndroidJNI.ToObjectArray(array); } 
public static Boolean[] FromBooleanArray(IntPtr array){ return AndroidJNI.FromBooleanArray(array); } 
public static Byte[] FromByteArray(IntPtr array){ return AndroidJNI.FromByteArray(array); } 
public static SByte[] FromSByteArray(IntPtr array){ return AndroidJNI.FromSByteArray(array); } 
public static Char[] FromCharArray(IntPtr array){ return AndroidJNI.FromCharArray(array); } 
public static Int16[] FromShortArray(IntPtr array){ return AndroidJNI.FromShortArray(array); } 
public static Int32[] FromIntArray(IntPtr array){ return AndroidJNI.FromIntArray(array); } 
public static Int64[] FromLongArray(IntPtr array){ return AndroidJNI.FromLongArray(array); } 
public static Single[] FromFloatArray(IntPtr array){ return AndroidJNI.FromFloatArray(array); } 
public static Double[] FromDoubleArray(IntPtr array){ return AndroidJNI.FromDoubleArray(array); } 
public static IntPtr[] FromObjectArray(IntPtr array){ return AndroidJNI.FromObjectArray(array); } 
public static Int32 GetArrayLength(IntPtr array){ return AndroidJNI.GetArrayLength(array); } 
public static IntPtr NewBooleanArray(Int32 size){ return AndroidJNI.NewBooleanArray(size); } 
public static IntPtr NewByteArray(Int32 size){ return AndroidJNI.NewByteArray(size); } 
public static IntPtr NewSByteArray(Int32 size){ return AndroidJNI.NewSByteArray(size); } 
public static IntPtr NewCharArray(Int32 size){ return AndroidJNI.NewCharArray(size); } 
public static IntPtr NewShortArray(Int32 size){ return AndroidJNI.NewShortArray(size); } 
public static IntPtr NewIntArray(Int32 size){ return AndroidJNI.NewIntArray(size); } 
public static IntPtr NewLongArray(Int32 size){ return AndroidJNI.NewLongArray(size); } 
public static IntPtr NewFloatArray(Int32 size){ return AndroidJNI.NewFloatArray(size); } 
public static IntPtr NewDoubleArray(Int32 size){ return AndroidJNI.NewDoubleArray(size); } 
public static IntPtr NewObjectArray(Int32 size, IntPtr clazz, IntPtr obj){ return AndroidJNI.NewObjectArray(size, clazz, obj); } 
public static Boolean GetBooleanArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetBooleanArrayElement(array, index); } 
public static Byte GetByteArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetByteArrayElement(array, index); } 
public static SByte GetSByteArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetSByteArrayElement(array, index); } 
public static Char GetCharArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetCharArrayElement(array, index); } 
public static Int16 GetShortArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetShortArrayElement(array, index); } 
public static Int32 GetIntArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetIntArrayElement(array, index); } 
public static Int64 GetLongArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetLongArrayElement(array, index); } 
public static Single GetFloatArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetFloatArrayElement(array, index); } 
public static Double GetDoubleArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetDoubleArrayElement(array, index); } 
public static IntPtr GetObjectArrayElement(IntPtr array, Int32 index){ return AndroidJNI.GetObjectArrayElement(array, index); } 
public static void SetBooleanArrayElement(IntPtr array, Int32 index, Byte val){ AndroidJNI.SetBooleanArrayElement(array, index, val); } 
public static void SetBooleanArrayElement(IntPtr array, Int32 index, Boolean val){ AndroidJNI.SetBooleanArrayElement(array, index, val); } 
public static void SetByteArrayElement(IntPtr array, Int32 index, SByte val){ AndroidJNI.SetByteArrayElement(array, index, val); } 
public static void SetSByteArrayElement(IntPtr array, Int32 index, SByte val){ AndroidJNI.SetSByteArrayElement(array, index, val); } 
public static void SetCharArrayElement(IntPtr array, Int32 index, Char val){ AndroidJNI.SetCharArrayElement(array, index, val); } 
public static void SetShortArrayElement(IntPtr array, Int32 index, Int16 val){ AndroidJNI.SetShortArrayElement(array, index, val); } 
public static void SetIntArrayElement(IntPtr array, Int32 index, Int32 val){ AndroidJNI.SetIntArrayElement(array, index, val); } 
public static void SetLongArrayElement(IntPtr array, Int32 index, Int64 val){ AndroidJNI.SetLongArrayElement(array, index, val); } 
public static void SetFloatArrayElement(IntPtr array, Int32 index, Single val){ AndroidJNI.SetFloatArrayElement(array, index, val); } 
public static void SetDoubleArrayElement(IntPtr array, Int32 index, Double val){ AndroidJNI.SetDoubleArrayElement(array, index, val); } 
public static void SetObjectArrayElement(IntPtr array, Int32 index, IntPtr obj){ AndroidJNI.SetObjectArrayElement(array, index, obj); } 
        #endregion
        
#else
        #region public static extern methods

        /// <summary>
        ///   <para>Attaches the current thread to a Java (Dalvik) VM.</para>
        /// </summary>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int AttachCurrentThread();

        /// <summary>
        ///   <para>Detaches the current thread from a Java (Dalvik) VM.</para>
        /// </summary>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int DetachCurrentThread();

        /// <summary>
        ///   <para>Returns the version of the native method interface.</para>
        /// </summary>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetVersion();

        /// <summary>
        ///   <para>This function loads a locally-defined class.</para>
        /// </summary>
        /// <param name="name"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr FindClass(string name);

        /// <summary>
        ///   <para>Converts a &lt;tt&gt;java.lang.reflect.Method&lt;tt&gt; or &lt;tt&gt;java.lang.reflect.Constructor&lt;tt&gt; object to a method ID.</para>
        /// </summary>
        /// <param name="refMethod"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr FromReflectedMethod(IntPtr refMethod);

        /// <summary>
        ///   <para>Converts a &lt;tt&gt;java.lang.reflect.Field&lt;/tt&gt; to a field ID.</para>
        /// </summary>
        /// <param name="refField"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr FromReflectedField(IntPtr refField);

        /// <summary>
        ///   <para>Converts a method ID derived from clazz to a &lt;tt&gt;java.lang.reflect.Method&lt;tt&gt; or &lt;tt&gt;java.lang.reflect.Constructor&lt;tt&gt; object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="isStatic"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToReflectedMethod(IntPtr clazz, IntPtr methodID, bool isStatic);

        /// <summary>
        ///   <para>Converts a field ID derived from cls to a &lt;tt&gt;java.lang.reflect.Field&lt;/tt&gt; object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="isStatic"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToReflectedField(IntPtr clazz, IntPtr fieldID, bool isStatic);

        /// <summary>
        ///   <para>If &lt;tt&gt;clazz&lt;tt&gt; represents any class other than the class &lt;tt&gt;Object&lt;tt&gt;, then this function returns the object that represents the superclass of the class specified by &lt;tt&gt;clazz&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="clazz"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetSuperclass(IntPtr clazz);

        /// <summary>
        ///   <para>Determines whether an object of &lt;tt&gt;clazz1&lt;tt&gt; can be safely cast to &lt;tt&gt;clazz2&lt;tt&gt;.</para>
        /// </summary>
        /// <param name="clazz1"></param>
        /// <param name="clazz2"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsAssignableFrom(IntPtr clazz1, IntPtr clazz2);

        /// <summary>
        ///   <para>Causes a &lt;tt&gt;java.lang.Throwable&lt;/tt&gt; object to be thrown.</para>
        /// </summary>
        /// <param name="obj"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int Throw(IntPtr obj);

        /// <summary>
        ///   <para>Constructs an exception object from the specified class with the &lt;tt&gt;message&lt;/tt&gt; specified by message and causes that exception to be thrown.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="message"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int ThrowNew(IntPtr clazz, string message);

        /// <summary>
        ///   <para>Determines if an exception is being thrown.</para>
        /// </summary>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ExceptionOccurred();

        /// <summary>
        ///   <para>Prints an exception and a backtrace of the stack to the &lt;tt&gt;logcat&lt;/tt&gt;</para>
        /// </summary>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void ExceptionDescribe();

        /// <summary>
        ///   <para>Clears any exception that is currently being thrown.</para>
        /// </summary>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void ExceptionClear();

        /// <summary>
        ///   <para>Raises a fatal error and does not expect the VM to recover. This function does not return.</para>
        /// </summary>
        /// <param name="message"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void FatalError(string message);

        /// <summary>
        ///   <para>Creates a new local reference frame, in which at least a given number of local references can be created.</para>
        /// </summary>
        /// <param name="capacity"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int PushLocalFrame(int capacity);

        /// <summary>
        ///   <para>Pops off the current local reference frame, frees all the local references, and returns a local reference in the previous local reference frame for the given &lt;tt&gt;result&lt;/tt&gt; object.</para>
        /// </summary>
        /// <param name="result"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr PopLocalFrame(IntPtr result);

        /// <summary>
        ///   <para>Creates a new global reference to the object referred to by the &lt;tt&gt;obj&lt;/tt&gt; argument.</para>
        /// </summary>
        /// <param name="obj"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewGlobalRef(IntPtr obj);

        /// <summary>
        ///   <para>Deletes the global reference pointed to by &lt;tt&gt;obj&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="obj"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void DeleteGlobalRef(IntPtr obj);

        /// <summary>
        ///   <para>Creates a new local reference that refers to the same object as &lt;tt&gt;obj&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="obj"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewLocalRef(IntPtr obj);

        /// <summary>
        ///   <para>Deletes the local reference pointed to by &lt;tt&gt;obj&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="obj"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void DeleteLocalRef(IntPtr obj);

        /// <summary>
        ///   <para>Tests whether two references refer to the same Java object.</para>
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsSameObject(IntPtr obj1, IntPtr obj2);

        /// <summary>
        ///   <para>Ensures that at least a given number of local references can be created in the current thread.</para>
        /// </summary>
        /// <param name="capacity"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int EnsureLocalCapacity(int capacity);

        /// <summary>
        ///   <para>Allocates a new Java object without invoking any of the constructors for the object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr AllocObject(IntPtr clazz);

        /// <summary>
        ///   <para>Constructs a new Java object. The method ID indicates which constructor method to invoke. This ID must be obtained by calling GetMethodID() with &lt;init&gt; as the method name and void (V) as the return type.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewObject(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Returns the class of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetObjectClass(IntPtr obj);

        /// <summary>
        ///   <para>Tests whether an object is an instance of a class.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="clazz"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsInstanceOf(IntPtr obj, IntPtr clazz);

        /// <summary>
        ///   <para>Returns the method ID for an instance (nonstatic) method of a class or interface.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="sig"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetMethodID(IntPtr clazz, string name, string sig);

        /// <summary>
        ///   <para>Returns the field ID for an instance (nonstatic) field of a class.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="sig"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetFieldID(IntPtr clazz, string name, string sig);

        /// <summary>
        ///   <para>Returns the method ID for a static method of a class.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="sig"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig);

        /// <summary>
        ///   <para>Returns the field ID for a static field of a class.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="name"></param>
        /// <param name="sig"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig);

        /// <summary>
        ///   <para>Constructs a new &lt;tt&gt;java.lang.String&lt;/tt&gt; object from an array of characters in modified UTF-8 encoding.</para>
        /// </summary>
        /// <param name="bytes"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewStringUTF(string bytes);

        /// <summary>
        ///   <para>Returns the length in bytes of the modified UTF-8 representation of a string.</para>
        /// </summary>
        /// <param name="str"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetStringUTFLength(IntPtr str);

        /// <summary>
        ///   <para>Returns a managed string object representing the string in modified UTF-8 encoding.</para>
        /// </summary>
        /// <param name="str"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetStringUTFChars(IntPtr str);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int CallIntMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool CallBooleanMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern short CallShortMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern byte CallByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern char CallCharMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float CallFloatMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double CallDoubleMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern long CallLongMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Calls an instance (nonstatic) Java method defined by &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void CallVoidMethod(IntPtr obj, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetStringField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetObjectField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool GetBooleanField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern byte GetByteField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern char GetCharField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern short GetShortField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetIntField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern long GetLongField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float GetFloatField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetDoubleField(IntPtr obj, IntPtr fieldID);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStringField(IntPtr obj, IntPtr fieldID, string val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetBooleanField(IntPtr obj, IntPtr fieldID, bool val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetByteField(IntPtr obj, IntPtr fieldID, byte val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetCharField(IntPtr obj, IntPtr fieldID, char val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetShortField(IntPtr obj, IntPtr fieldID, short val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetIntField(IntPtr obj, IntPtr fieldID, int val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetLongField(IntPtr obj, IntPtr fieldID, long val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetFloatField(IntPtr obj, IntPtr fieldID, float val);

        /// <summary>
        ///   <para>This function sets the value of an instance (nonstatic) field of an object.</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetDoubleField(IntPtr obj, IntPtr fieldID, double val);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern byte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>Invokes a static method on a Java object, according to the specified &lt;tt&gt;methodID&lt;tt&gt;, optionally passing an array of arguments (&lt;tt&gt;args&lt;tt&gt;) to the method.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="methodID"></param>
        /// <param name="args"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, jvalue[] args);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetStaticStringField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern byte GetStaticByteField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern char GetStaticCharField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern short GetStaticShortField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetStaticIntField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern long GetStaticLongField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float GetStaticFloatField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function returns the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticStringField(IntPtr clazz, IntPtr fieldID, string val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticByteField(IntPtr clazz, IntPtr fieldID, byte val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float val);

        /// <summary>
        ///   <para>This function ets the value of a static field of an object.</para>
        /// </summary>
        /// <param name="clazz"></param>
        /// <param name="fieldID"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double val);

        /// <summary>
        ///   <para>Convert a managed array of System.Boolean to a Java array of &lt;tt&gt;boolean&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToBooleanArray(bool[] array);

        /// <summary>
        ///   <para>Convert a managed array of System.Byte to a Java array of &lt;tt&gt;byte&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToByteArray(byte[] array);

        /// <summary>
        ///   <para>Convert a managed array of System.Char to a Java array of &lt;tt&gt;char&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToCharArray(char[] array);

        /// <summary>
        ///   <para>Convert a managed array of System.Int16 to a Java array of &lt;tt&gt;short&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToShortArray(short[] array);

        /// <summary>
        ///   <para>Convert a managed array of System.Int32 to a Java array of &lt;tt&gt;int&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToIntArray(int[] array);

        /// <summary>
        ///   <para>Convert a managed array of System.Int64 to a Java array of &lt;tt&gt;long&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToLongArray(long[] array);

        /// <summary>
        ///   <para>Convert a managed array of System.Single to a Java array of &lt;tt&gt;float&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToFloatArray(float[] array);

        /// <summary>
        ///   <para>Convert a managed array of System.Double to a Java array of &lt;tt&gt;double&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToDoubleArray(double[] array);

        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr ToObjectArray(IntPtr[] array, IntPtr arrayClass);

        /// <summary>
        ///   <para>Convert a managed array of System.IntPtr, representing Java objects, to a Java array of &lt;tt&gt;java.lang.Object&lt;/tt&gt;.</para>
        /// </summary>
        /// <param name="array"></param>
        public static IntPtr ToObjectArray(IntPtr[] array)
        {
            return MyAndroidJNI.ToObjectArray(array, IntPtr.Zero);
        }

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;boolean&lt;/tt&gt; to a managed array of System.Boolean.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool[] FromBooleanArray(IntPtr array);

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;byte&lt;/tt&gt; to a managed array of System.Byte.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern byte[] FromByteArray(IntPtr array);

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;char&lt;/tt&gt; to a managed array of System.Char.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern char[] FromCharArray(IntPtr array);

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;short&lt;/tt&gt; to a managed array of System.Int16.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern short[] FromShortArray(IntPtr array);

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;int&lt;/tt&gt; to a managed array of System.Int32.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int[] FromIntArray(IntPtr array);

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;long&lt;/tt&gt; to a managed array of System.Int64.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern long[] FromLongArray(IntPtr array);

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;float&lt;/tt&gt; to a managed array of System.Single.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float[] FromFloatArray(IntPtr array);

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;double&lt;/tt&gt; to a managed array of System.Double.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double[] FromDoubleArray(IntPtr array);

        /// <summary>
        ///   <para>Convert a Java array of &lt;tt&gt;java.lang.Object&lt;/tt&gt; to a managed array of System.IntPtr, representing Java objects.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr[] FromObjectArray(IntPtr array);

        /// <summary>
        ///   <para>Returns the number of elements in the array.</para>
        /// </summary>
        /// <param name="array"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetArrayLength(IntPtr array);

        /// <summary>
        ///   <para>Construct a new primitive array object.</para>
        /// </summary>
        /// <param name="size"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewBooleanArray(int size);

        /// <summary>
        ///   <para>Construct a new primitive array object.</para>
        /// </summary>
        /// <param name="size"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewByteArray(int size);

        /// <summary>
        ///   <para>Construct a new primitive array object.</para>
        /// </summary>
        /// <param name="size"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewCharArray(int size);

        /// <summary>
        ///   <para>Construct a new primitive array object.</para>
        /// </summary>
        /// <param name="size"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewShortArray(int size);

        /// <summary>
        ///   <para>Construct a new primitive array object.</para>
        /// </summary>
        /// <param name="size"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewIntArray(int size);

        /// <summary>
        ///   <para>Construct a new primitive array object.</para>
        /// </summary>
        /// <param name="size"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewLongArray(int size);

        /// <summary>
        ///   <para>Construct a new primitive array object.</para>
        /// </summary>
        /// <param name="size"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewFloatArray(int size);

        /// <summary>
        ///   <para>Construct a new primitive array object.</para>
        /// </summary>
        /// <param name="size"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewDoubleArray(int size);

        /// <summary>
        ///   <para>Constructs a new array holding objects in class &lt;tt&gt;clazz&lt;tt&gt;. All elements are initially set to &lt;tt&gt;obj&lt;tt&gt;.</para>
        /// </summary>
        /// <param name="size"></param>
        /// <param name="clazz"></param>
        /// <param name="obj"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr NewObjectArray(int size, IntPtr clazz, IntPtr obj);

        /// <summary>
        ///   <para>Returns the value of one element of a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool GetBooleanArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Returns the value of one element of a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern byte GetByteArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Returns the value of one element of a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern char GetCharArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Returns the value of one element of a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern short GetShortArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Returns the value of one element of a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetIntArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Returns the value of one element of a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern long GetLongArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Returns the value of one element of a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float GetFloatArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Returns the value of one element of a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetDoubleArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Returns an element of an &lt;tt&gt;Object&lt;/tt&gt; array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern IntPtr GetObjectArrayElement(IntPtr array, int index);

        /// <summary>
        ///   <para>Sets the value of one element in a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetBooleanArrayElement(IntPtr array, int index, byte val);

        /// <summary>
        ///   <para>Sets the value of one element in a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetByteArrayElement(IntPtr array, int index, sbyte val);

        /// <summary>
        ///   <para>Sets the value of one element in a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetCharArrayElement(IntPtr array, int index, char val);

        /// <summary>
        ///   <para>Sets the value of one element in a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetShortArrayElement(IntPtr array, int index, short val);

        /// <summary>
        ///   <para>Sets the value of one element in a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetIntArrayElement(IntPtr array, int index, int val);

        /// <summary>
        ///   <para>Sets the value of one element in a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetLongArrayElement(IntPtr array, int index, long val);

        /// <summary>
        ///   <para>Sets the value of one element in a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetFloatArrayElement(IntPtr array, int index, float val);

        /// <summary>
        ///   <para>Sets the value of one element in a primitive array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="val"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetDoubleArrayElement(IntPtr array, int index, double val);

        /// <summary>
        ///   <para>Sets an element of an &lt;tt&gt;Object&lt;/tt&gt; array.</para>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="obj"></param>
        // [WrapperlessIcall]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetObjectArrayElement(IntPtr array, int index, IntPtr obj);
        #endregion
#endif

    }
}