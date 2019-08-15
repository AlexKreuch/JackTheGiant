// Decompiled with JetBrains decompiler
// Type: UnityEngine.AndroidReflection
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A8FF7A2C-E4EE-4232-AB17-3FCABEC16496
// Assembly location: C:\Users\Blake\sandbox\unity\test-project\Library\UnityAssemblies\UnityEngine.dll

using System;

namespace UnityEngine
{
  internal class MyAndroidReflection
  {
       

        private static IntPtr s_ReflectionHelperClass = MyAndroidJNI.NewGlobalRef(MyAndroidJNISafe.FindClass("com/unity3d/player/ReflectionHelper"));
        private static IntPtr s_ReflectionHelperGetConstructorID = MyAndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "getConstructorID", "(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/reflect/Constructor;");
        private static IntPtr s_ReflectionHelperGetMethodID = MyAndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "getMethodID", "(Ljava/lang/Class;Ljava/lang/String;Ljava/lang/String;Z)Ljava/lang/reflect/Method;");
        private static IntPtr s_ReflectionHelperGetFieldID = MyAndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "getFieldID", "(Ljava/lang/Class;Ljava/lang/String;Ljava/lang/String;Z)Ljava/lang/reflect/Field;");
        private static IntPtr s_ReflectionHelperNewProxyInstance = MyAndroidReflection.GetStaticMethodID("com/unity3d/player/ReflectionHelper", "newProxyInstance", "(ILjava/lang/Class;)Ljava/lang/Object;");
        private const string RELECTION_HELPER_CLASS_NAME = "com/unity3d/player/ReflectionHelper";

        public static bool IsPrimitive(System.Type t)
        {
          return t.IsPrimitive;
        }

        public static bool IsAssignableFrom(System.Type t, System.Type from)
        {
          return t.IsAssignableFrom(from);
        }

        private static IntPtr GetStaticMethodID(string clazz, string methodName, string signature)
        {
          IntPtr num = MyAndroidJNISafe.FindClass(clazz);
          try
          {
            return MyAndroidJNISafe.GetStaticMethodID(num, methodName, signature);
          }
          finally
          {
            MyAndroidJNISafe.DeleteLocalRef(num);
          }
        }

        public static IntPtr GetConstructorMember(IntPtr jclass, string signature)
        {
          jvalue[] args = new jvalue[2];
          try
          {
            args[0].l = jclass;
            args[1].l = MyAndroidJNISafe.NewStringUTF(signature);
            return MyAndroidJNISafe.CallStaticObjectMethod(MyAndroidReflection.s_ReflectionHelperClass, MyAndroidReflection.s_ReflectionHelperGetConstructorID, args);
          }
          finally
          {
            MyAndroidJNISafe.DeleteLocalRef(args[1].l);
          }
        }

        public static IntPtr GetMethodMember(IntPtr jclass, string methodName, string signature, bool isStatic)
        {
          jvalue[] args = new jvalue[4];
          try
          {
            args[0].l = jclass;
            args[1].l = MyAndroidJNISafe.NewStringUTF(methodName);
            args[2].l = MyAndroidJNISafe.NewStringUTF(signature);
            args[3].z = isStatic;
            return MyAndroidJNISafe.CallStaticObjectMethod(MyAndroidReflection.s_ReflectionHelperClass, MyAndroidReflection.s_ReflectionHelperGetMethodID, args);
          }
          finally
          {
            MyAndroidJNISafe.DeleteLocalRef(args[1].l);
            MyAndroidJNISafe.DeleteLocalRef(args[2].l);
          }
        }

        public static IntPtr GetFieldMember(IntPtr jclass, string fieldName, string signature, bool isStatic)
        {
          jvalue[] args = new jvalue[4];
          try
          {
            args[0].l = jclass;
            args[1].l = MyAndroidJNISafe.NewStringUTF(fieldName);
            args[2].l = MyAndroidJNISafe.NewStringUTF(signature);
            args[3].z = isStatic;
            return MyAndroidJNISafe.CallStaticObjectMethod(MyAndroidReflection.s_ReflectionHelperClass, MyAndroidReflection.s_ReflectionHelperGetFieldID, args);
          }
          finally
          {
            MyAndroidJNISafe.DeleteLocalRef(args[1].l);
            MyAndroidJNISafe.DeleteLocalRef(args[2].l);
          }
        }

        public static IntPtr NewProxyInstance(int delegateHandle, IntPtr interfaze)
        {
          jvalue[] args = new jvalue[2];
          args[0].i = delegateHandle;
          args[1].l = interfaze;
          return MyAndroidJNISafe.CallStaticObjectMethod(MyAndroidReflection.s_ReflectionHelperClass, MyAndroidReflection.s_ReflectionHelperNewProxyInstance, args);
        }
      }
}