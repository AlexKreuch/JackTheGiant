#define TESTING00
// Decompiled with JetBrains decompiler
// Type: UnityEngine.AndroidJNISafe
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8FF7A2C-E4EE-4232-AB17-3FCABEC16496
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEngine.dll

using System;

namespace UnityEngine
{
  internal class MyAndroidJNISafe
  {
        

        public static void CheckException()
        {
            /* Check for an exception in AndroidJNI. If one is found, then throw and analogous exception
             * 
                NOTE : I wrote this comment
             */
            IntPtr localref = MyAndroidJNI.ExceptionOccurred();
            if (!(localref != IntPtr.Zero))
            return;
            MyAndroidJNI.ExceptionClear();
            IntPtr num1 = MyAndroidJNI.FindClass("java/lang/Throwable");
            IntPtr num2 = MyAndroidJNI.FindClass("android/util/Log");
            try
            {
                IntPtr methodId = MyAndroidJNI.GetMethodID(num1, "toString", "()Ljava/lang/String;");
                IntPtr staticMethodId = MyAndroidJNI.GetStaticMethodID(num2, "getStackTraceString", "(Ljava/lang/Throwable;)Ljava/lang/String;");
                string message = MyAndroidJNI.CallStringMethod(localref, methodId, new jvalue[0]);
                jvalue[] args = new jvalue[1];
                args[0].l = localref;
                string javaStackTrace = MyAndroidJNI.CallStaticStringMethod(num2, staticMethodId, args);
                #region appease compiler ~~ AndroidJavaException
#if TESTING00
                throw new Exception(string.Format("psudo AndroidJavaException : \n message : \n{0} \n javaStackTrace\n {1}",message,javaStackTrace));
#else
                throw new AndroidJavaException(message, javaStackTrace);
#endif
                #endregion
            }
            finally
            {
                MyAndroidJNISafe.DeleteLocalRef(localref);
                MyAndroidJNISafe.DeleteLocalRef(num1);
                MyAndroidJNISafe.DeleteLocalRef(num2);
            }
        }

        public static void DeleteGlobalRef(IntPtr globalref)
        {
          if (!(globalref != IntPtr.Zero))
            return;
          MyAndroidJNI.DeleteGlobalRef(globalref);
        }

        public static void DeleteLocalRef(IntPtr localref)
        {
          if (!(localref != IntPtr.Zero)) return;
          MyAndroidJNI.DeleteLocalRef(localref);
        }

        public static IntPtr NewStringUTF(string bytes)
        {
          try
          {
            return MyAndroidJNI.NewStringUTF(bytes);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static string GetStringUTFChars(IntPtr str)
        {
          try
          {
            return MyAndroidJNI.GetStringUTFChars(str);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr GetObjectClass(IntPtr ptr)
        {
          try
          {
            return MyAndroidJNI.GetObjectClass(ptr);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig)
        {
          try
          {
            return MyAndroidJNI.GetStaticMethodID(clazz, name, sig);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr GetMethodID(IntPtr obj, string name, string sig)
        {
          try
          {
            return MyAndroidJNI.GetMethodID(obj, name, sig);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr GetFieldID(IntPtr clazz, string name, string sig)
        {
          try
          {
            return MyAndroidJNI.GetFieldID(clazz, name, sig);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig)
        {
          try
          {
            return MyAndroidJNI.GetStaticFieldID(clazz, name, sig);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr FromReflectedMethod(IntPtr refMethod)
        {
          try
          {
            return MyAndroidJNI.FromReflectedMethod(refMethod);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr FromReflectedField(IntPtr refField)
        {
          try
          {
            return MyAndroidJNI.FromReflectedField(refField);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr FindClass(string name)
        {
          try
          {
            return MyAndroidJNI.FindClass(name);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.NewObject(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr val)
        {
          try
          {
            MyAndroidJNI.SetStaticObjectField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticStringField(IntPtr clazz, IntPtr fieldID, string val)
        {
          try
          {
            MyAndroidJNI.SetStaticStringField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char val)
        {
          try
          {
            MyAndroidJNI.SetStaticCharField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double val)
        {
          try
          {
            MyAndroidJNI.SetStaticDoubleField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float val)
        {
          try
          {
            MyAndroidJNI.SetStaticFloatField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long val)
        {
          try
          {
            MyAndroidJNI.SetStaticLongField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short val)
        {
          try
          {
            MyAndroidJNI.SetStaticShortField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticByteField(IntPtr clazz, IntPtr fieldID, byte val)
        {
          try
          {
            MyAndroidJNI.SetStaticByteField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool val)
        {
          try
          {
            MyAndroidJNI.SetStaticBooleanField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int val)
        {
          try
          {
            MyAndroidJNI.SetStaticIntField(clazz, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticObjectField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static string GetStaticStringField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticStringField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static char GetStaticCharField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticCharField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticDoubleField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static float GetStaticFloatField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticFloatField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static long GetStaticLongField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticLongField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static short GetStaticShortField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticShortField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static byte GetStaticByteField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticByteField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticBooleanField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static int GetStaticIntField(IntPtr clazz, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStaticIntField(clazz, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            MyAndroidJNI.CallStaticVoidMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticObjectMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticStringMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticCharMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticDoubleMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticFloatMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticLongMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticShortMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static byte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticByteMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticBooleanMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStaticIntMethod(clazz, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr val)
        {
          try
          {
            MyAndroidJNI.SetObjectField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetStringField(IntPtr obj, IntPtr fieldID, string val)
        {
          try
          {
            MyAndroidJNI.SetStringField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetCharField(IntPtr obj, IntPtr fieldID, char val)
        {
          try
          {
            MyAndroidJNI.SetCharField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetDoubleField(IntPtr obj, IntPtr fieldID, double val)
        {
          try
          {
            MyAndroidJNI.SetDoubleField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetFloatField(IntPtr obj, IntPtr fieldID, float val)
        {
          try
          {
            MyAndroidJNI.SetFloatField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetLongField(IntPtr obj, IntPtr fieldID, long val)
        {
          try
          {
            MyAndroidJNI.SetLongField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetShortField(IntPtr obj, IntPtr fieldID, short val)
        {
          try
          {
            MyAndroidJNI.SetShortField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetByteField(IntPtr obj, IntPtr fieldID, byte val)
        {
          try
          {
            MyAndroidJNI.SetByteField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetBooleanField(IntPtr obj, IntPtr fieldID, bool val)
        {
          try
          {
            MyAndroidJNI.SetBooleanField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void SetIntField(IntPtr obj, IntPtr fieldID, int val)
        {
          try
          {
            MyAndroidJNI.SetIntField(obj, fieldID, val);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr GetObjectField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetObjectField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static string GetStringField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetStringField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static char GetCharField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetCharField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static double GetDoubleField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetDoubleField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static float GetFloatField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetFloatField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static long GetLongField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetLongField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static short GetShortField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetShortField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static byte GetByteField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetByteField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static bool GetBooleanField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetBooleanField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static int GetIntField(IntPtr obj, IntPtr fieldID)
        {
          try
          {
            return MyAndroidJNI.GetIntField(obj, fieldID);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static void CallVoidMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            MyAndroidJNI.CallVoidMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallObjectMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static string CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallStringMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static char CallCharMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallCharMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallDoubleMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static float CallFloatMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallFloatMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static long CallLongMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallLongMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static short CallShortMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallShortMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static byte CallByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallByteMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallBooleanMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static int CallIntMethod(IntPtr obj, IntPtr methodID, jvalue[] args)
        {
          try
          {
            return MyAndroidJNI.CallIntMethod(obj, methodID, args);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr[] FromObjectArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromObjectArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static char[] FromCharArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromCharArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static double[] FromDoubleArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromDoubleArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static float[] FromFloatArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromFloatArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static long[] FromLongArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromLongArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static short[] FromShortArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromShortArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static byte[] FromByteArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromByteArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static bool[] FromBooleanArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromBooleanArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static int[] FromIntArray(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.FromIntArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToObjectArray(IntPtr[] array)
        {
          try
          {
            return MyAndroidJNI.ToObjectArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToObjectArray(IntPtr[] array, IntPtr type)
        {
          try
          {
            return MyAndroidJNI.ToObjectArray(array, type);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToCharArray(char[] array)
        {
          try
          {
            return MyAndroidJNI.ToCharArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToDoubleArray(double[] array)
        {
          try
          {
            return MyAndroidJNI.ToDoubleArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToFloatArray(float[] array)
        {
          try
          {
            return MyAndroidJNI.ToFloatArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToLongArray(long[] array)
        {
          try
          {
            return MyAndroidJNI.ToLongArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToShortArray(short[] array)
        {
          try
          {
            return MyAndroidJNI.ToShortArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToByteArray(byte[] array)
        {
          try
          {
            return MyAndroidJNI.ToByteArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToBooleanArray(bool[] array)
        {
          try
          {
            return MyAndroidJNI.ToBooleanArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr ToIntArray(int[] array)
        {
          try
          {
            return MyAndroidJNI.ToIntArray(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static IntPtr GetObjectArrayElement(IntPtr array, int index)
        {
          try
          {
            return MyAndroidJNI.GetObjectArrayElement(array, index);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }

        public static int GetArrayLength(IntPtr array)
        {
          try
          {
            return MyAndroidJNI.GetArrayLength(array);
          }
          finally
          {
            MyAndroidJNISafe.CheckException();
          }
        }
  }
}