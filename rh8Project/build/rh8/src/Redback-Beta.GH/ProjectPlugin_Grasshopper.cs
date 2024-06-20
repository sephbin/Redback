using System;
using SD = System.Drawing;

using Rhino;
using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class AssemblyInfo : GH_AssemblyInfo
  {
    public override Guid Id { get; } = new Guid("7d142de6-7a37-4b73-961b-a5ef3f7bfbc8");

    public override string AssemblyName { get; } = "Redback-Beta.GH";
    public override string AssemblyVersion { get; } = "0.3.1.8938";
    public override string AssemblyDescription { get; } = "";
    public override string AuthorName { get; } = "Andrew Butler";
    public override string AuthorContact { get; } = "andrew.butler@strangercollective.com";
    public override GH_LibraryLicense AssemblyLicense { get; } = GH_LibraryLicense.unset;
    public override SD.Bitmap AssemblyIcon { get; } = ProjectComponentPlugin.PluginIcon;
  }

  public class ProjectComponentPlugin : GH_AssemblyPriority
  {
    public static SD.Bitmap PluginIcon { get; }
    public static SD.Bitmap PluginCategoryIcon { get; }

    static readonly Guid s_rhinocode = new Guid("c9cba87a-23ce-4f15-a918-97645c05cde7");
    static readonly Type s_invokeContextType = default;
    static readonly dynamic s_projectServer = default;
    static readonly object s_project = default;

    static readonly Guid s_projectId = new Guid("7d142de6-7a37-4b73-961b-a5ef3f7bfbc8");
    static readonly string s_projectData = "ew0KICAiaWQiOiAiN2QxNDJkZTYtN2EzNy00YjczLTk2MWItYTVlZjNmN2JmYmM4IiwNCiAgImlkZW50aXR5Ijogew0KICAgICJuYW1lIjogIlJlZGJhY2stQmV0YSIsDQogICAgInZlcnNpb24iOiAiMC4zLjEtYmV0YSIsDQogICAgInB1Ymxpc2hlciI6IHsNCiAgICAgICJlbWFpbCI6ICJhbmRyZXcuYnV0bGVyQHN0cmFuZ2VyY29sbGVjdGl2ZS5jb20iLA0KICAgICAgIm5hbWUiOiAiQW5kcmV3IEJ1dGxlciIsDQogICAgICAiY29tcGFueSI6ICJTdHJhbmdlciBDb2xsZWN0aXZlIiwNCiAgICAgICJjb3VudHJ5IjogIkF1c3RyYWxpYSIsDQogICAgICAidXJsIjogImh0dHBzOi8vZ2l0aHViLmNvbS9zZXBoYmluLyINCiAgICB9LA0KICAgICJjb3B5cmlnaHQiOiAiQ29weXJpZ2h0IFx1MDBBOSAyMDI0ICIsDQogICAgImltYWdlIjogew0KICAgICAgImxpZ2h0Ijogew0KICAgICAgICAidHlwZSI6ICJzdmciLA0KICAgICAgICAiZGF0YSI6ICJQSE4yWnlCcFpEMGlUR0Y1WlhKZk1TSWdaR0YwWVMxdVlXMWxQU0pNWVhsbGNpQXhJaUI0Yld4dWN6MGlhSFIwY0RvdkwzZDNkeTUzTXk1dmNtY3ZNakF3TUM5emRtY2lJSGh0Ykc1ek9uaHNhVzVyUFNKb2RIUndPaTh2ZDNkM0xuY3pMbTl5Wnk4eE9UazVMM2hzYVc1cklpQjJhV1YzUW05NFBTSXdJREFnT1RZZ01UQXhMamM0SWo0S0lDQThaR1ZtY3o0S0lDQWdJRHh6ZEhsc1pUNEtJQ0FnSUNBZ0xtTnNjeTB4SUhzS0lDQWdJQ0FnSUNCbWFXeHNPaUFqTWpNeFpqSXdPd29nSUNBZ0lDQjlDZ29nSUNBZ0lDQXVZMnh6TFRFc0lDNWpiSE10TWl3Z0xtTnNjeTB6SUhzS0lDQWdJQ0FnSUNCemRISnZhMlV0ZDJsa2RHZzZJREJ3ZURzS0lDQWdJQ0FnZlFvS0lDQWdJQ0FnTG1Oc2N5MHlJSHNLSUNBZ0lDQWdJQ0JtYVd4c09pQWpaV0l3WVRoak93b2dJQ0FnSUNCOUNnb2dJQ0FnSUNBdVkyeHpMVE1nZXdvZ0lDQWdJQ0FnSUdacGJHdzZJRzV2Ym1VN0NpQWdJQ0FnSUgwS0NpQWdJQ0FnSUM1amJITXROQ0I3Q2lBZ0lDQWdJQ0FnWTJ4cGNDMXdZWFJvT2lCMWNtd29JMk5zYVhCd1lYUm9LVHNLSUNBZ0lDQWdmUW9nSUNBZ1BDOXpkSGxzWlQ0S0lDQWdJRHhqYkdsd1VHRjBhQ0JwWkQwaVkyeHBjSEJoZEdnaVBnb2dJQ0FnSUNBOGNHRjBhQ0JqYkdGemN6MGlZMnh6TFRNaUlHUTlJazA0Tnk0ME1TdzJNeTQzT0dNd0xESTFMalk1TFRFM0xqWTFMRE0yTGpVeUxUTTVMalF4TERNMkxqVXlVemt1TlRrc09Ea3VORGNzT1M0MU9TdzJNeTQzT0N3eU5pNHlNeXczTGpJMkxEUTRMRGN1TWpaek16a3VOREVzTXpBdU9ETXNNemt1TkRFc05UWXVOVEphSWk4XHUwMDJCQ2lBZ0lDQThMMk5zYVhCUVlYUm9QZ29nSUR3dlpHVm1jejRLSUNBOFp5QmpiR0Z6Y3owaVkyeHpMVFFpUGdvZ0lDQWdQSEpsWTNRZ1kyeGhjM005SW1Oc2N5MHhJaUI1UFNJMUxqYzRJaUIzYVdSMGFEMGlPVFlpSUdobGFXZG9kRDBpT1RZaUx6NEtJQ0FnSUR4eVpXTjBJR05zWVhOelBTSmpiSE10TWlJZ2VEMGlNemN1TkRRaUlIZHBaSFJvUFNJeU1TNHhNU0lnYUdWcFoyaDBQU0kyTXk0ek15SWdjbmc5SWpraUlISjVQU0k1SWk4XHUwMDJCQ2lBZ1BDOW5QZ284TDNOMlp6ND0iDQogICAgICB9LA0KICAgICAgImRhcmsiOiB7DQogICAgICAgICJ0eXBlIjogInN2ZyIsDQogICAgICAgICJkYXRhIjogIlBITjJaeUJwWkQwaVRHRjVaWEpmTVNJZ1pHRjBZUzF1WVcxbFBTSk1ZWGxsY2lBeElpQjRiV3h1Y3owaWFIUjBjRG92TDNkM2R5NTNNeTV2Y21jdk1qQXdNQzl6ZG1jaUlIaHRiRzV6T25oc2FXNXJQU0pvZEhSd09pOHZkM2QzTG5jekxtOXlaeTh4T1RrNUwzaHNhVzVySWlCMmFXVjNRbTk0UFNJd0lEQWdPVFlnTVRBeExqYzRJajRLSUNBOFpHVm1jejRLSUNBZ0lEeHpkSGxzWlQ0S0lDQWdJQ0FnTG1Oc2N5MHhJSHNLSUNBZ0lDQWdJQ0JtYVd4c09pQWpNak14WmpJd093b2dJQ0FnSUNCOUNnb2dJQ0FnSUNBdVkyeHpMVEVzSUM1amJITXRNaXdnTG1Oc2N5MHpJSHNLSUNBZ0lDQWdJQ0J6ZEhKdmEyVXRkMmxrZEdnNklEQndlRHNLSUNBZ0lDQWdmUW9LSUNBZ0lDQWdMbU5zY3kweUlIc0tJQ0FnSUNBZ0lDQm1hV3hzT2lBalpXSXdZVGhqT3dvZ0lDQWdJQ0I5Q2dvZ0lDQWdJQ0F1WTJ4ekxUTWdld29nSUNBZ0lDQWdJR1pwYkd3NklHNXZibVU3Q2lBZ0lDQWdJSDBLQ2lBZ0lDQWdJQzVqYkhNdE5DQjdDaUFnSUNBZ0lDQWdZMnhwY0Mxd1lYUm9PaUIxY213b0kyTnNhWEJ3WVhSb0tUc0tJQ0FnSUNBZ2ZRb2dJQ0FnUEM5emRIbHNaVDRLSUNBZ0lEeGpiR2x3VUdGMGFDQnBaRDBpWTJ4cGNIQmhkR2dpUGdvZ0lDQWdJQ0E4Y0dGMGFDQmpiR0Z6Y3owaVkyeHpMVE1pSUdROUlrMDROeTQwTVN3Mk15NDNPR013TERJMUxqWTVMVEUzTGpZMUxETTJMalV5TFRNNUxqUXhMRE0yTGpVeVV6a3VOVGtzT0RrdU5EY3NPUzQxT1N3Mk15NDNPQ3d5Tmk0eU15dzNMakkyTERRNExEY3VNalp6TXprdU5ERXNNekF1T0RNc016a3VOREVzTlRZdU5USmFJaThcdTAwMkJDaUFnSUNBOEwyTnNhWEJRWVhSb1Bnb2dJRHd2WkdWbWN6NEtJQ0E4WnlCamJHRnpjejBpWTJ4ekxUUWlQZ29nSUNBZ1BISmxZM1FnWTJ4aGMzTTlJbU5zY3kweElpQjVQU0kxTGpjNElpQjNhV1IwYUQwaU9UWWlJR2hsYVdkb2REMGlPVFlpTHo0S0lDQWdJRHh5WldOMElHTnNZWE56UFNKamJITXRNaUlnZUQwaU16Y3VORFFpSUhkcFpIUm9QU0l5TVM0eE1TSWdhR1ZwWjJoMFBTSTJNeTR6TXlJZ2NuZzlJamtpSUhKNVBTSTVJaThcdTAwMkJDaUFnUEM5blBnbzhMM04yWno0PSINCiAgICAgIH0NCiAgICB9DQogIH0sDQogICJzZXR0aW5ncyI6IHsNCiAgICAiYnVpbGRQYXRoIjogImZpbGU6Ly8vRTovbXlkZXYvcmVkYmFjay9yaDhQcm9qZWN0L2J1aWxkL3JoOCIsDQogICAgImJ1aWxkVGFyZ2V0Ijogew0KICAgICAgImFwcE5hbWUiOiAiUmhpbm8zRCIsDQogICAgICAiYXBwVmVyc2lvbiI6IHsNCiAgICAgICAgIm1ham9yIjogOA0KICAgICAgfSwNCiAgICAgICJ0aXRsZSI6ICJSaGlubzNEICg4LiopIiwNCiAgICAgICJzbHVnIjogInJoOCINCiAgICB9LA0KICAgICJwdWJsaXNoVGFyZ2V0Ijogew0KICAgICAgInRpdGxlIjogIk1jTmVlbCBZYWsgU2VydmVyIg0KICAgIH0NCiAgfSwNCiAgImNvZGVzIjogW10NCn0=";
    static readonly string _iconData = "ew0KICAibGlnaHQiOiB7DQogICAgInR5cGUiOiAic3ZnIiwNCiAgICAiZGF0YSI6ICJQSE4yWnlCcFpEMGlUR0Y1WlhKZk1TSWdaR0YwWVMxdVlXMWxQU0pNWVhsbGNpQXhJaUI0Yld4dWN6MGlhSFIwY0RvdkwzZDNkeTUzTXk1dmNtY3ZNakF3TUM5emRtY2lJSGh0Ykc1ek9uaHNhVzVyUFNKb2RIUndPaTh2ZDNkM0xuY3pMbTl5Wnk4eE9UazVMM2hzYVc1cklpQjJhV1YzUW05NFBTSXdJREFnT1RZZ01UQXhMamM0SWo0S0lDQThaR1ZtY3o0S0lDQWdJRHh6ZEhsc1pUNEtJQ0FnSUNBZ0xtTnNjeTB4SUhzS0lDQWdJQ0FnSUNCbWFXeHNPaUFqTWpNeFpqSXdPd29nSUNBZ0lDQjlDZ29nSUNBZ0lDQXVZMnh6TFRFc0lDNWpiSE10TWl3Z0xtTnNjeTB6SUhzS0lDQWdJQ0FnSUNCemRISnZhMlV0ZDJsa2RHZzZJREJ3ZURzS0lDQWdJQ0FnZlFvS0lDQWdJQ0FnTG1Oc2N5MHlJSHNLSUNBZ0lDQWdJQ0JtYVd4c09pQWpaV0l3WVRoak93b2dJQ0FnSUNCOUNnb2dJQ0FnSUNBdVkyeHpMVE1nZXdvZ0lDQWdJQ0FnSUdacGJHdzZJRzV2Ym1VN0NpQWdJQ0FnSUgwS0NpQWdJQ0FnSUM1amJITXROQ0I3Q2lBZ0lDQWdJQ0FnWTJ4cGNDMXdZWFJvT2lCMWNtd29JMk5zYVhCd1lYUm9LVHNLSUNBZ0lDQWdmUW9nSUNBZ1BDOXpkSGxzWlQ0S0lDQWdJRHhqYkdsd1VHRjBhQ0JwWkQwaVkyeHBjSEJoZEdnaVBnb2dJQ0FnSUNBOGNHRjBhQ0JqYkdGemN6MGlZMnh6TFRNaUlHUTlJazA0Tnk0ME1TdzJNeTQzT0dNd0xESTFMalk1TFRFM0xqWTFMRE0yTGpVeUxUTTVMalF4TERNMkxqVXlVemt1TlRrc09Ea3VORGNzT1M0MU9TdzJNeTQzT0N3eU5pNHlNeXczTGpJMkxEUTRMRGN1TWpaek16a3VOREVzTXpBdU9ETXNNemt1TkRFc05UWXVOVEphSWk4XHUwMDJCQ2lBZ0lDQThMMk5zYVhCUVlYUm9QZ29nSUR3dlpHVm1jejRLSUNBOFp5QmpiR0Z6Y3owaVkyeHpMVFFpUGdvZ0lDQWdQSEpsWTNRZ1kyeGhjM005SW1Oc2N5MHhJaUI1UFNJMUxqYzRJaUIzYVdSMGFEMGlPVFlpSUdobGFXZG9kRDBpT1RZaUx6NEtJQ0FnSUR4eVpXTjBJR05zWVhOelBTSmpiSE10TWlJZ2VEMGlNemN1TkRRaUlIZHBaSFJvUFNJeU1TNHhNU0lnYUdWcFoyaDBQU0kyTXk0ek15SWdjbmc5SWpraUlISjVQU0k1SWk4XHUwMDJCQ2lBZ1BDOW5QZ284TDNOMlp6ND0iDQogIH0sDQogICJkYXJrIjogew0KICAgICJ0eXBlIjogInN2ZyIsDQogICAgImRhdGEiOiAiUEhOMlp5QnBaRDBpVEdGNVpYSmZNU0lnWkdGMFlTMXVZVzFsUFNKTVlYbGxjaUF4SWlCNGJXeHVjejBpYUhSMGNEb3ZMM2QzZHk1M015NXZjbWN2TWpBd01DOXpkbWNpSUhodGJHNXpPbmhzYVc1clBTSm9kSFJ3T2k4dmQzZDNMbmN6TG05eVp5OHhPVGs1TDNoc2FXNXJJaUIyYVdWM1FtOTRQU0l3SURBZ09UWWdNVEF4TGpjNElqNEtJQ0E4WkdWbWN6NEtJQ0FnSUR4emRIbHNaVDRLSUNBZ0lDQWdMbU5zY3kweElIc0tJQ0FnSUNBZ0lDQm1hV3hzT2lBak1qTXhaakl3T3dvZ0lDQWdJQ0I5Q2dvZ0lDQWdJQ0F1WTJ4ekxURXNJQzVqYkhNdE1pd2dMbU5zY3kweklIc0tJQ0FnSUNBZ0lDQnpkSEp2YTJVdGQybGtkR2c2SURCd2VEc0tJQ0FnSUNBZ2ZRb0tJQ0FnSUNBZ0xtTnNjeTB5SUhzS0lDQWdJQ0FnSUNCbWFXeHNPaUFqWldJd1lUaGpPd29nSUNBZ0lDQjlDZ29nSUNBZ0lDQXVZMnh6TFRNZ2V3b2dJQ0FnSUNBZ0lHWnBiR3c2SUc1dmJtVTdDaUFnSUNBZ0lIMEtDaUFnSUNBZ0lDNWpiSE10TkNCN0NpQWdJQ0FnSUNBZ1kyeHBjQzF3WVhSb09pQjFjbXdvSTJOc2FYQndZWFJvS1RzS0lDQWdJQ0FnZlFvZ0lDQWdQQzl6ZEhsc1pUNEtJQ0FnSUR4amJHbHdVR0YwYUNCcFpEMGlZMnhwY0hCaGRHZ2lQZ29nSUNBZ0lDQThjR0YwYUNCamJHRnpjejBpWTJ4ekxUTWlJR1E5SWswNE55NDBNU3cyTXk0M09HTXdMREkxTGpZNUxURTNMalkxTERNMkxqVXlMVE01TGpReExETTJMalV5VXprdU5Ua3NPRGt1TkRjc09TNDFPU3cyTXk0M09Dd3lOaTR5TXl3M0xqSTJMRFE0TERjdU1qWnpNemt1TkRFc016QXVPRE1zTXprdU5ERXNOVFl1TlRKYUlpOFx1MDAyQkNpQWdJQ0E4TDJOc2FYQlFZWFJvUGdvZ0lEd3ZaR1ZtY3o0S0lDQThaeUJqYkdGemN6MGlZMnh6TFRRaVBnb2dJQ0FnUEhKbFkzUWdZMnhoYzNNOUltTnNjeTB4SWlCNVBTSTFMamM0SWlCM2FXUjBhRDBpT1RZaUlHaGxhV2RvZEQwaU9UWWlMejRLSUNBZ0lEeHlaV04wSUdOc1lYTnpQU0pqYkhNdE1pSWdlRDBpTXpjdU5EUWlJSGRwWkhSb1BTSXlNUzR4TVNJZ2FHVnBaMmgwUFNJMk15NHpNeUlnY25nOUlqa2lJSEo1UFNJNUlpOFx1MDAyQkNpQWdQQzluUGdvOEwzTjJaejQ9Ig0KICB9DQp9";

    static ProjectComponentPlugin()
    {
      s_projectServer = ProjectInterop.GetProjectServer();
      if (s_projectServer is null)
      {
        RhinoApp.WriteLine($"Error loading Grasshopper plugin. Missing Rhino3D platform");
        return;
      }

      // get project
      dynamic dctx = ProjectInterop.CreateInvokeContext();
      dctx.Inputs["projectAssembly"] = typeof(ProjectComponentPlugin).Assembly;
      dctx.Inputs["projectId"] = s_projectId;
      dctx.Inputs["projectData"] = s_projectData;

      object project = default;
      if (s_projectServer.TryInvoke("plugins/v1/deserialize", dctx)
            && dctx.Outputs.TryGet("project", out project))
      {
        // server reports errors
        s_project = project;
      }

      // get icons
      if (!_iconData.Contains("ASSEMBLY-ICON"))
      {
        dynamic ictx = ProjectInterop.CreateInvokeContext();
        ictx.Inputs["iconData"] = _iconData;
        SD.Bitmap icon = default;
        if (s_projectServer.TryInvoke("plugins/v1/icon/gh/assembly", ictx)
              && ictx.Outputs.TryGet("icon", out icon))
        {
          // server reports errors
          PluginIcon = icon;
        }

        if (s_projectServer.TryInvoke("plugins/v1/icon/gh/category", ictx)
              && ictx.Outputs.TryGet("icon", out icon))
        {
          // server reports errors
          PluginCategoryIcon = icon;
        }
      }
    }

    public override GH_LoadingInstruction PriorityLoad()
    {
      Grasshopper.Instances.ComponentServer.AddCategorySymbolName("Redback-Beta", "Redback-Beta"[0]);

      if (PluginCategoryIcon != null)
        Grasshopper.Instances.ComponentServer.AddCategoryIcon("Redback-Beta", PluginCategoryIcon);

      return GH_LoadingInstruction.Proceed;
    }

    public static bool TryCreateScript(GH_Component ghcomponent, string serialized, out object script)
    {
      script = default;

      if (s_projectServer is null) return false;

      dynamic dctx = ProjectInterop.CreateInvokeContext();
      dctx.Inputs["component"] = ghcomponent;
      dctx.Inputs["project"] = s_project;
      dctx.Inputs["scriptData"] = serialized;

      if (s_projectServer.TryInvoke("plugins/v1/gh/deserialize", dctx))
      {
        return dctx.Outputs.TryGet("script", out script);
      }

      return false;
    }

    public static bool TryCreateScriptIcon(object script, out SD.Bitmap icon)
    {
      icon = default;

      if (s_projectServer is null) return false;

      dynamic ictx = ProjectInterop.CreateInvokeContext();
      ictx.Inputs["script"] = script;

      if (s_projectServer.TryInvoke("plugins/v1/icon/gh/script", ictx))
      {
        // server reports errors
        return ictx.Outputs.TryGet("icon", out icon);
      }

      return false;
    }

    public static void DisposeScript(GH_Component ghcomponent, object script)
    {
      if (script is null)
        return;

      dynamic dctx = ProjectInterop.CreateInvokeContext();
      dctx.Inputs["component"] = ghcomponent;
      dctx.Inputs["project"] = s_project;
      dctx.Inputs["script"] = script;

      if (!s_projectServer.TryInvoke("plugins/v1/gh/dispose", dctx))
        throw new Exception("Error disposing Grasshopper script component");
    }
  }
}
