using System;
using SD = System.Drawing;

using Rhino.Geometry;

using Grasshopper.Kernel;

namespace RhinoCodePlatform.Rhino3D.Projects.Plugin.GH
{
  public sealed class ProjectComponent_ef5a6f3f : GH_Component
  {
    readonly SD.Bitmap _icon = default;
    readonly string _scriptData = "ew0KICAidHlwZSI6ICJzY3JpcHQiLA0KICAic2NyaXB0Ijogew0KICAgICJsYW5ndWFnZSI6IHsNCiAgICAgICJpZCI6ICIqLioucHl0aG9uIiwNCiAgICAgICJ2ZXJzaW9uIjogIjIuKi4qIg0KICAgIH0sDQogICAgInRpdGxlIjogIlN0eWxlU1ZHIiwNCiAgICAidGV4dCI6ICJiVzlrU1c1a1pYZ2dQU0JiWFEwS1ptOXlJR2tzSUd4cGJtVWdhVzRnWlc1MWJXVnlZWFJsS0ZOV1J5azZEUW9nSUNBZ2FXWWdJanh3Y21WVGRIbHNaUzhcdTAwMkJJaUJwYmlCc2FXNWxMbk4wY21sd0tDazZEUW9nSUNBZ0lDQWdJRzF2WkVsdVpHVjRMbUZ3Y0dWdVpDaHBLUTBLWm05eUlHa2dhVzRnYlc5a1NXNWtaWGc2RFFvZ0lDQWdVMVpIVzJsZElEMGdJaUl1YW05cGJpaERVMU1wIiwNCiAgICAidXJpIjogInJoaW5vY29kZTovLy9ncmFzc2hvcHBlci8xL2VmNWE2ZjNmLTYzYjAtNGM4OS1iNTAzLWQ3NTA3NTA5NmVjMy8iLA0KICAgICJpZCI6ICJlZjVhNmYzZi02M2IwLTRjODktYjUwMy1kNzUwNzUwOTZlYzMiLA0KICAgICJuaWNrbmFtZSI6ICJTdHlsZVNWRyIsDQogICAgImltYWdlIjogew0KICAgICAgImxpZ2h0Ijogew0KICAgICAgICAidHlwZSI6ICJzdmciLA0KICAgICAgICAiZGF0YSI6ICJQSE4yWnlCMlpYSnphVzl1UFNJeExqRWlJSGh0Ykc1elBTSm9kSFJ3T2k4dmQzZDNMbmN6TG05eVp5OHlNREF3TDNOMlp5SWdlRzFzYm5NNmVHeHBibXM5SW1oMGRIQTZMeTkzZDNjdWR6TXViM0puTHpFNU9Ua3ZlR3hwYm1zaUlIZzlJakJ3ZUNJZ2VUMGlNSEI0SWdvZ0lDQWdkMmxrZEdnOUlqSTBiVzBpSUdobGFXZG9kRDBpTWpSdGJTSWdkbWxsZDBKdmVEMGlNQ0F3SURJMElESTBJaUI0Yld3NmMzQmhZMlU5SW5CeVpYTmxjblpsSWo0S0lDQWdJRHh6ZEhsc1pTQjBlWEJsUFNKMFpYaDBMMk56Y3lJXHUwMDJCQ2lBZ0lDQXVabWxzYkMxM2FHbDBaWHRtYVd4c09uZG9hWFJsTzMwS0xtWnBiR3d0Y21Wa2UyWnBiR3c2STJWa01XTXlORHQ5Q2lBZ0lDQThMM04wZVd4bFBnb2dJQ0FnUEhCaGRHZ2daRDBpSUUwMUxqRXpMREUxTGpjMUlFdzFMalF4TERFM0xqRXdJRXcxTGpVekxERTNMalUySUV3MUxqWTVMREU0TGpBeUlFdzFMamsxTERFNExqVTNJRXcyTGpJM0xERTVMakE0SUV3MkxqUTRMREU1TGpNMklFdzJMamN4TERFNUxqWXpJRXczTGpFNExESXdMakE0SUV3M0xqVXdMREl3TGpNeklFdzNMamcxTERJd0xqVTJJRXc0TGpJd0xESXdMamMzSUV3NExqVTNMREl3TGprMklFdzVMakU0TERJeExqSXlJRXc1TGpneExESXhMalF5SUV3eE1DNDBOQ3d5TVM0MU9TQk1NVEV1TURnc01qRXVOekFnVERFeExqY3dMREl4TGpjNElFd3hNaTR6TkN3eU1TNDRNU0JNTVRJdU9UWXNNakV1T0RBZ1RERXpMalU0TERJeExqYzBJRXd4TkM0eE9Td3lNUzQyTVNCTU1UUXVOVEVzTWpFdU5URWdUREUwTGpneUxESXhMalF3SUV3eE5TNHhNU3d5TVM0eU55Qk1NVFV1TkRFc01qRXVNVEVnVERFMUxqWTVMREl3TGpreklFd3hOUzQ1Tnl3eU1DNDNNeUJNTVRZdU1qSXNNakF1TlRFZ1RERTJMalExTERJd0xqSTRJRXd4Tmk0Mk5Td3lNQzR3TlNCTU1UY3VNRE1zTVRrdU5UUWdUREUzTGpNekxERTVMakF4SUV3eE55NDFOeXd4T0M0ME5TQk1NVGN1TnpRc01UY3VPRGNnVERFM0xqZzFMREUzTGpJNElFd3hOeTQ0T0N3eE5pNDVNQ0JNTVRjdU9EZ3NNVFl1TlRJZ1RERTNMamcxTERFMkxqRXpJRXd4Tnk0M05pd3hOUzQyTlNCTU1UY3VOVEVzTVRRdU5UQWdUREUzTGpNNExERXpMams1SUV3eE55NHlNQ3d4TXk0MU1DQk1NVFl1T1RVc01UTXVNRFFnVERFMkxqWTFMREV5TGpZeUlFd3hOeTR3TVN3eE1pNHlNeUJNTVRjdU16TXNNVEV1T0RRZ1RERTNMall5TERFeExqUTBJRXd4Tnk0NE9Td3hNUzR3TWlCTU1UZ3VNVFFzTVRBdU5Ua2dUREU0TGpNNExERXdMakV4SUV3eE9DNDFPQ3c1TGpZeElFd3hPQzQzTml3NUxqQTRJRXd4T0M0NU1DdzRMalV6SUV3eE9DNDVPU3czTGprM0lFd3hPUzR3TVN3M0xqTTVJRXd4T0M0NU55dzJMamd5SUV3eE9DNDVNQ3cyTGpReklFd3hPQzQyTml3MUxqTXpJRXd4T0M0MU1TdzBMamMySUV3eE9DNHpOU3cwTGpNMUlFd3hPQzR5TVN3MExqQTRJRXd4T0M0d05Td3pMamd6SUV3eE55NDROeXd6TGpVNUlFd3hOeTQyTml3ekxqTTNJRXd4Tnk0ME5Td3pMakU0SUV3eE55NHlNeXd6TGpBd0lFd3hOaTQ1T1N3eUxqZ3pJRXd4Tmk0M05Dd3lMalk1SUV3eE5pNHlNeXd5TGpRMklFd3hOUzQzTUN3eUxqTXhJRXd4TlM0ek9Td3lMakkxSUV3eE5TNHdPQ3d5TGpJeElFd3hOQzQwTml3eUxqRTVJRXd4TXk0NU1pd3lMakl5SUV3eE15NHpPQ3d5TGpNeElFd3hNaTQ0TlN3eUxqUTBJRXd4TWk0ek15d3lMall4SUV3eE1TNDVNQ3d5TGpjNUlFd3hNUzQwTnl3eUxqazVJRXd4TUM0NU9Dd3pMakkzSUV3eE1DNDFNU3d6TGpVM0lFd3hNQzR3Tml3ekxqa3hJRXc1TGpZeUxEUXVNamNnVERrdU1qRXNOQzQyTlNCTU9DNDRNaXcxTGpBMklFdzRMalExTERVdU5Ea2dURGd1TVRJc05TNDVOQ0JNTnk0M05DdzJMalV3SUV3M0xqUTRMRFl1T1RjZ1REY3VNalFzTnk0ME5pQk1OeTR3TlN3M0xqazFJRXcyTGprd0xEZ3VORFVnVERZdU56Z3NPUzR3TUNCTU5pNDNNaXc1TGpRMUlFdzJMamN4TERrdU9URWdURFl1TnpVc01UQXVORFVnVERZdU5EWXNNVEF1TmpJZ1REWXVNakFzTVRBdU9ESWdURFV1T1RNc01URXVNVEVnVERVdU56QXNNVEV1TkRJZ1REVXVOVElzTVRFdU56UWdURFV1TXpjc01USXVNRGdnVERVdU1qVXNNVEl1TkRRZ1REVXVNVFlzTVRJdU9ERWdURFV1TURnc01UTXVNakVnVERVdU1ESXNNVE11TmpJZ1REUXVPVGtzTVRRdU1Ea2dURFF1T1Rrc01UUXVOVFVnVERVdU1ESXNNVFV1TURkYUlpQjZMV2x1WkdWNFBTSXdJaUJqYkdGemN6MGlabWxzYkMxM2FHbDBaU0l2UGdvOGNHRjBhQ0JrUFNJZ1RUUXlMamMzTERFM0xqQTFJRXcwTXk0d09Td3hOaTQzTXlCTU5ETXVNekFzTVRZdU5EWWdURFF6TGpRNExERTJMakUzSUV3ME15NDJNeXd4TlM0NE15Qk1ORE11TnpBc01UVXVOalFnVERRekxqYzNMREUxTGpJMklFdzBNeTQzT0N3eE5TNHdOaUJNTkRNdU56Y3NNVFF1T0RZZ1REUXpMamN5TERFMExqWTJJRXcwTXk0Mk5Td3hOQzQwTnlCTU5ETXVOVFVzTVRRdU1qa2dURFF6TGpReExERTBMakV6SUV3ME15NHlOaXd4TkM0d01DQk1ORE11TURrc01UTXVPRGtnVERReUxqa3lMREV6TGpneUlFdzBNaTQzTXl3eE15NDNOaUJNTkRJdU5USXNNVE11TnpNZ1REUXlMak13TERFekxqY3lJRXcwTVM0NU15d3hNeTQzTmlCTU5ERXVOVGNzTVRNdU9EY2dURFF4TGpJM0xERTBMakF3SUV3ME1DNDVOQ3d4TkM0eU1DQk1OREF1TmpNc01UUXVORFFnVERRd0xqTTFMREUwTGpjeUlFdzBNQzR4TVN3eE5TNHdNaUJNTXprdU9UZ3NNVFV1TWpJZ1RETTVMamd3TERFMUxqVTFJRXd6T1M0Mk9Dd3hOUzQ0T1NCTU16a3VOalFzTVRZdU1EZ2dURE01TGpZeUxERTJMalF3SUV3ek9TNDJNeXd4Tmk0MU9DQk1Nemt1TkRRc01UWXVOekVnVERNNUxqSTNMREUyTGpreUlFd3pPUzR4TlN3eE55NHhOU0JNTXprdU1EZ3NNVGN1TkRBZ1RETTVMakF6TERFM0xqWTRJRXd6T1M0d01pd3hPQzR3TVNCTU16a3VNRFlzTVRndU16WWdURE01TGpFM0xERTRMamMwSUV3ek9TNHlOU3d4T0M0NU15Qk1Nemt1TXpZc01Ua3VNVEVnVERNNUxqVXlMREU1TGpNd0lFd3pPUzQyT0N3eE9TNDBOU0JNTXprdU9URXNNVGt1TmpJZ1REUXdMakUyTERFNUxqYzJJRXcwTUM0MU9Td3hPUzQ1TWlCTU5ERXVNRE1zTWpBdU1ESWdURFF4TGpRM0xESXdMakEySUV3ME1TNDVNQ3d5TUM0d015Qk1OREl1TWpJc01Ua3VPVFVnVERReUxqUXpMREU1TGpnM0lFdzBNaTQyTXl3eE9TNDNOU0JNTkRJdU9ERXNNVGt1TmpBZ1REUXlMamsyTERFNUxqUTBJRXcwTXk0d09Td3hPUzR5TnlCTU5ETXVNakFzTVRrdU1EZ2dURFF6TGpJNExERTRMamc1SUV3ME15NHpOQ3d4T0M0Mk9TQk1ORE11TXpnc01UZ3VORGdnVERRekxqTTVMREU0TGpJeUlFdzBNeTR6Tnl3eE9DNHdNaUJNTkRNdU16SXNNVGN1T0RJZ1REUXpMakl4TERFM0xqVTJJRXcwTXk0eE1Td3hOeTQwTUNCTU5ESXVPVGtzTVRjdU1qVmFJaUF2UGdvOGNHRjBhQ0JrUFNJZ1RUVTFMams1TERFM0xqazRJRXcxTlM0NU1Dd3hPQzR5TVNCTU5UVXVORGdzTVRndU56UWdURFUwTGprNUxERTVMak13SUV3MU5DNDFOU3d4T1M0M01pQk1OVFF1TWprc01Ua3VPVE1nVERVMExqQXhMREl3TGpFeUlFdzFNeTQzTWl3eU1DNHpNQ0JNTlRNdU5ESXNNakF1TkRRZ1REVXpMakV5TERJd0xqVTJJRXcxTWk0NE1Dd3lNQzQyTlNCTU5USXVOVE1zTWpBdU5qa2dURFV5TGpJMkxESXdMamN3SUV3MU1pNHdOU3d5TUM0Mk9DQk1OVEV1T0RRc01qQXVOalVnVERVeExqVTRMREl3TGpVM0lFdzFNUzR5TkN3eU1DNHpPU0JNTlRFdU1UZ3NNakF1TkRjZ1REVXhMakEyTERJd0xqVTVJRXcxTUM0NE9Td3lNQzQyT1NCTU5UQXVOekFzTWpBdU56UWdURFV3TGpVeExESXdMamMxSUV3MU1DNHpOQ3d5TUM0M01pQk1OVEF1TVRBc01qQXVOalVnVERRNUxqZzFMREl3TGpVMklFdzBPUzQ0TkN3eU1DNDNPQ0JNTkRrdU56a3NNakV1TURFZ1REUTVMall4TERJeExqYzJJRXcwT1M0MU55d3lNUzQ0T1NCTU5Ea3VORFVzTWpJdU1Ua2dURFE1TGpNeExESXlMalEzSUV3ME9TNHdOeXd5TWk0NE1TQk1ORGd1T0RNc01qTXVNRGtnVERRNExqVTJMREl6TGpNMElFdzBPQzR5T1N3eU15NDFOU0JNTkRjdU9Ua3NNak11TnpNZ1REUTNMalk1TERJekxqZzRJRXcwTnk0ek55d3lNeTQ1T1NCTU5EY3VNRElzTWpRdU1EZ2dURFEyTGpZM0xESTBMakV6SUV3ME5pNHpOeXd5TkM0eE5TQk1ORFl1TURjc01qUXVNVE1nVERRMUxqYzVMREkwTGpBNElFdzBOUzQxTlN3eU5DNHdNU0JNTkRVdU16UXNNak11T1RJZ1REUTFMakUxTERJekxqZ3dJRXcwTkM0NU9Dd3lNeTQyTmlCTU5EUXVPRElzTWpNdU5URWdURFEwTGpZNUxESXpMak16SUV3ME5DNDFOeXd5TXk0eE5DQk1ORFF1TkRnc01qSXVPVFFnVERRMExqUXhMREl5TGpjeklFdzBOQzR6TlN3eU1pNDFNU0JNTkRRdU16SXNNakl1TWpnZ1REUTBMak13TERJeExqZzJJRXcwTkM0ek15d3lNUzQxTkNCTU5ETXVPRGtzTWpFdU5qRWdURFF6TGpNM0xESXhMamMySUV3ME1pNDRNaXd5TVM0NU5pQk1OREF1TlRZc01qSXVPVFlnVERRd0xqRXhMREl6TGpFeklFd3pPUzQyTlN3eU15NHlOaUJNTXprdU1qQXNNak11TXpZZ1RETTRMamMzTERJekxqUXhJRXd6T0M0ek55d3lNeTQwTWlCTU16Y3VPVFlzTWpNdU16a2dURE0zTGpZd0xESXpMak14SUV3ek55NHpNQ3d5TXk0eU1DQk1NemN1TURFc01qTXVNRFFnVERNMkxqYzJMREl5TGpneUlFd3pOaTQxT0N3eU1pNDFOeUJNTXpZdU5EUXNNakl1TXpBZ1RETTJMak0yTERJeUxqQXlJRXd6Tmk0ek1Td3lNUzQzTlNCTU16WXVNekVzTWpFdU16Y2dURE0yTGpNMkxESXhMakV3SUV3ek5pNDFOQ3d5TUM0ek15Qk1Nell1TmpFc01qQXVNVE1nVERNMkxqWTVMREU1TGprNUlFd3pOaTQ0TkN3eE9TNDRNeUJNTXpjdU1ETXNNVGt1TnpJZ1RETTNMakl4TERFNUxqWTRJRXd6Tnk0ek5Dd3hPUzQyT0NCTU16Y3VOVGdzTVRrdU56TWdURE0zTGpnMUxERTVMamcySUV3ek9DNHlNQ3d4T1M0NU5DQk1Nemd1TkRnc01Ua3VPVGNnVERNNExqazJMREU1TGprMUlFd3pPUzR4Tml3eE9TNDVOQ0JNTXpndU9UY3NNVGt1TlRrZ1RETTRMamc1TERFNUxqTTJJRXd6T0M0NE5Td3hPUzR4TlNCTU16Z3VPRElzTVRndU56SWdURE00TGpnMUxERTRMak0ySUV3ek9DNDVNQ3d4T0M0eE5TQk1Nemt1TURnc01UY3VOREFnVERNNUxqRTVMREUzTGpBMklFd3pPUzR5Tnl3eE5pNDVNeUJNTXprdU16WXNNVFl1T0RBZ1RETTVMalE1TERFMkxqWTNJRXd6T1M0Mk5pd3hOUzQ1TnlCTU16a3VPREFzTVRVdU5UVWdURE01TGprNExERTFMakl5SUV3ME1DNHhNU3d4TlM0d01pQk1OREF1TXpVc01UUXVOeklnVERRd0xqY3lMREUwTGpNMklFdzBNQzQxTml3eE5DNHlNeUJNTkRBdU5ESXNNVFF1TURjZ1REUXdMakk1TERFekxqZzVJRXcwTUM0eE9Td3hNeTQyT1NCTU5EQXVNVElzTVRNdU5EZ2dURFF3TGpBNExERXpMakkzSUV3ME1DNHdPQ3d4TXk0d05TQk1OREF1TVRJc01USXVOemdnVERRd0xqTXhMREV5TGpBd0lFdzBNQzR6T0N3eE1TNDNPU0JNTkRBdU5EY3NNVEV1TlRrZ1REUXdMalkwTERFeExqTTFJRXcwTUM0M09Td3hNUzR5TWlCTU5EQXVPVGtzTVRFdU1UTWdURFF4TGpBNExERXhMakV4SUV3ME1TNHpOQ3d4TVM0eE1pQk1OREV1TlRRc01URXVNVGtnVERReExqZ3lMREV4TGpNM0lFdzBNaTR4TWl3eE1TNDFNaUJNTkRJdU5ETXNNVEV1TmpJZ1REUXlMamsxTERFeExqY3dJRXcwTXk0MU1Td3hNUzQzTlNCTU5EUXVOekVzTVRFdU56a2dURFExTGpFd0xERXhMamM1SUV3ME5TNHpOaXd4TVM0MU1DQk1ORFV1TmpNc01URXVNamdnVERRMUxqZzBMREV4TGpFM0lFdzBOaTR3T0N3eE1TNHdPU0JNTkRZdU16TXNNVEV1TURZZ1REUTJMalU0TERFeExqQTJJRXcwTmk0NE1Td3hNUzR3T1NCTU5EY3VNRFFzTVRFdU1UWWdURFEzTGpJeExERXhMakkwSUV3ME55NHpPQ3d4TVM0ek5TQk1ORGN1TlRVc01URXVORGtnVERRM0xqYzFMREV4TGpjMUlFdzBOeTQ0TXl3eE1TNDVOQ0JNTkRndU5EY3NNVEl1TVRBZ1REUTRMamcyTERFeUxqSTJJRXcwT1M0eE5pd3hNaTQwTlNCTU5Ea3VNek1zTVRJdU5qSWdURFE1TGpRNExERXlMamcxSUV3ME9TNDFOU3d4TXk0d015Qk1ORGt1TmpFc01UTXVNamtnVERRNUxqWXhMREV6TGpRNUlFdzBPUzQxTnl3eE15NDNOQ0JNTkRrdU5EUXNNVFF1TXpBZ1REUTVMall6TERFMExqTTVJRXcwT1M0NE1pd3hOQzQxTUNCTU5UQXVNRFlzTVRNdU9ETWdURFV3TGpNekxERXpMakU0SUV3MU1DNDJPQ3d4TWk0ME5TQk1OVEF1T1RZc01URXVPVFlnVERVeExqRXlMREV4TGpjeklFdzFNUzR6TUN3eE1TNDFNeUJNTlRFdU5Ea3NNVEV1TXpjZ1REVXhMamN3TERFeExqSTBJRXcxTVM0NU5Dd3hNUzR4TkNCTU5USXVNak1zTVRFdU1Ea2dURFV5TGpVMUxERXhMakE1SUV3MU1pNDNNaXd4TVM0eE1pQk1OVEl1T0Rrc01URXVNVFlnVERVekxqQTRMREV4TGpJMUlFdzFNeTR6Tml3eE1TNDBNeUJNTlRNdU5qQXNNVEV1TmpjZ1REVXpMamN3TERFeExqZ3hJRXcxTXk0NE1Dd3hNaTR3TWlCTU5UTXVPRE1zTVRJdU1qQWdURFV6TGpnMExERXlMak0wSUV3MU15NDRNU3d4TWk0ME9TQk1OVE11TmpJc01UTXVNallnVERVekxqVTFMREV6TGpRM0lFdzFNeTQwTVN3eE15NDJOU0JNTlRNdU1UVXNNVE11T1RRZ1REVXlMamM1TERFMExqUTNJRXcxTXk0eU15d3hOQzR5TlNCTU5UTXVOVGdzTVRRdU1UTWdURFV6TGprMkxERTBMakE0SUV3MU5DNHhOaXd4TkM0d09DQk1OVFF1TkRFc01UUXVNVElnVERVMExqWXpMREUwTGpJd0lFdzFOQzQ0TkN3eE5DNHpNaUJNTlRVdU1ETXNNVFF1TkRnZ1REVTFMakU1TERFMExqWTNJRXcxTlM0ek1Td3hOQzQ0T0NCTU5UVXVNemdzTVRVdU1UTWdURFUxTGpRd0xERTFMak00SUV3MU5TNHpPQ3d4TlM0Mk1pQk1OVFV1TXpRc01UVXVPREFnVERVMUxqSXlMREUyTGpJM0lFdzFOUzQwT0N3eE5pNHlNeUJNTlRVdU5qa3NNVFl1TWpVZ1REVTFMamcyTERFMkxqTXlJRXcxTmk0d01Dd3hOaTQwTXlCTU5UWXVNVElzTVRZdU5UZ2dURFUyTGpFM0xERTJMamN3SUV3MU5pNHlNaXd4Tmk0NU1pQk1OVFl1TWpBc01UY3VNVFlnVERVMkxqRTVMREUzTGpFNVdpSWdlaTFwYm1SbGVEMGlNQ0lnWTJ4aGMzTTlJbVpwYkd3dGQyaHBkR1VpTHo0S1BIQmhkR2dnWkQwaUlFMHhNeTQxTnl3MkxqRXlJRXd4TXk0Mk5TdzJMakl3SUV3eE15NDNNQ3cyTGpNMUlFd3hNeTQzTXl3MkxqVTJJRXd4TXk0M01pdzJMamcwSUV3eE15NDJOeXczTGpFM0lFd3hNeTQxT0N3M0xqVXlJRXd4TXk0ME5TdzNMamt3SUV3eE15NHlOaXc0TGpJNElFd3hNeTR3TVN3NExqWTNJRXd4TWk0M01TdzVMakEySUV3eE1pNHdOaXc1TGpneklFd3hNUzQ1TXl3eE1DNHdNaUJNTVRFdU9ESXNNVEF1TWpFZ1RERXhMamMwTERFd0xqTTVJRXd4TVM0M01Dd3hNQzQxTnlCTU1URXVOekFzTVRBdU56UWdUREV4TGpjMExERXdMamt3SUV3eE1TNDRNeXd4TVM0d05DQk1NVEV1T1Rjc01URXVNVGNnVERFeUxqRTBMREV4TGpJMklFd3hNaTR6TlN3eE1TNHpNeUJNTVRJdU5Ua3NNVEV1TXpZZ1RERXlMamczTERFeExqTTJJRXd4TXk0eE55d3hNUzR6TUNCTU1UTXVOVEFzTVRFdU1qRWdUREV6TGpnMExERXhMakEySUV3eE5DNHhPU3d4TUM0NE55Qk1NVFF1TlRVc01UQXVOaklnVERFMExqa3dMREV3TGpNeUlFd3hOUzR5Tml3NUxqazRJRXd4TlM0Mk1DdzVMalU0SUV3eE5TNDVNaXc1TGpFMUlFd3hOaTR5TWl3NExqWTVJRXd4Tmk0ME9DdzRMakl3SUV3eE5pNDNNQ3czTGpjd0lFd3hOaTQ0Tnl3M0xqRTVJRXd4Tmk0NU9DdzJMalk1SUV3eE55NHdNeXcyTGpJeUlFd3hOeTR3TVN3MUxqYzNJRXd4Tmk0NU1pdzFMak0ySUV3eE5pNDNOeXcwTGprNUlFd3hOaTQxTlN3MExqWTNJRXd4Tmk0eU9DdzBMalF3SUV3eE5TNDVOU3cwTGpFNUlFd3hOUzQxTnl3MExqQXpJRXd4TlM0eE5pd3pMamt6SUV3eE5DNDNNaXd6TGpnNElFd3hOQzR5Tml3ekxqa3dJRXd4TXk0M09Dd3pMamsySUV3eE15NHlPU3cwTGpBNElFd3hNaTQ0TUN3MExqSTFJRXd4TWk0ek1TdzBMalEzSUV3eE1TNDRNeXcwTGpjMElFd3hNUzR6Tml3MUxqQTFJRXd4TUM0NU1TdzFMalF3SUV3eE1DNDBPQ3cxTGpjNElFd3hNQzR3T0N3MkxqSXdJRXc1TGpjeExEWXVOalFnVERrdU16Z3NOeTR3T1NCTU9TNHdPU3czTGpVMklFdzRMamcxTERndU1ETWdURGd1TmpZc09DNDBPU0JNT0M0MU1pdzRMamswSUV3NExqUTBMRGt1TXprZ1REZ3VOREVzT1M0NE1TQk1PQzQwTXl3eE1DNHlNU0JNT0M0MU1Dd3hNQzQxT0NCTU9DNDJNaXd4TUM0NU15Qk1PQzQzT1N3eE1TNHlOQ0JNT1M0d01Dd3hNUzQxTXlCTU9TNHlOU3d4TVM0M09DQk1PUzQxTkN3eE1pNHdNU0JNT1M0NE5Td3hNaTR5TVNCTU1UQXVNVGdzTVRJdU16a2dUREV3TGpVekxERXlMalUwSUV3eE1TNDVNU3d4TXk0d055Qk1NVEl1TlRFc01UTXVNek1nVERFekxqQXhMREV6TGpZd0lFd3hNeTQwTVN3eE15NDRPQ0JNTVRNdU5qa3NNVFF1TVRZZ1RERXpMamM0TERFMExqTXdJRXd4TXk0NE5Td3hOQzQwTkNCTU1UTXVPRGtzTVRRdU5UY2dUREV6TGpreExERTBMamN3SUV3eE15NDVNQ3d4TkM0NE1pQk1NVE11T0RZc01UUXVPVE1nVERFekxqZ3dMREUxTGpBeklFd3hNeTQzTVN3eE5TNHhNU0JNTVRNdU5qQXNNVFV1TVRrZ1RERXpMalEzTERFMUxqSTFJRXd4TXk0ek1pd3hOUzR5T1NCTU1UTXVNVFVzTVRVdU16SWdUREV5TGpjMUxERTFMak16SUV3eE1pNHlPU3d4TlM0eU55Qk1NVEV1Tnpjc01UVXVNVE1nVERFeExqSXpMREUwTGprMElFd3hNQzQyT0N3eE5DNDNNU0JNTVRBdU1UVXNNVFF1TkRVZ1REa3VOamdzTVRRdU1UY2dURGt1TWpZc01UTXVPRGtnVERndU9USXNNVE11TlRnZ1REZ3VOallzTVRNdU1qWWdURGd1TkRnc01USXVPVE1nVERndU1qSXNNVEl1TXpJZ1REZ3VNVEFzTVRJdU1UQWdURGd1TURNc01USXVNREVnVERjdU9UVXNNVEV1T1RVZ1REY3VPRGNzTVRFdU9USWdURGN1Tnpnc01URXVPVEFnVERjdU5qQXNNVEV1T1RNZ1REY3VOREVzTVRJdU1ETWdURGN1TWpNc01USXVNakFnVERjdU1EY3NNVEl1TkRVZ1REWXVPVElzTVRJdU56Z2dURFl1T0RFc01UTXVNakVnVERZdU56SXNNVE11TnpNZ1REWXVOamdzTVRRdU16SWdURFl1TnpFc01UUXVPVFVnVERZdU56WXNNVFV1TWpnZ1REWXVPRE1zTVRVdU5qQWdURFl1T1RRc01UVXVPVElnVERjdU1EWXNNVFl1TWpRZ1REY3VNak1zTVRZdU5UUWdURGN1TkRJc01UWXVPRE1nVERjdU5qVXNNVGN1TVRFZ1REY3VPVEVzTVRjdU16Y2dURGd1TWpFc01UY3VOaklnVERndU5UVXNNVGN1T0RRZ1REZ3VPVEVzTVRndU1EUWdURGt1TXpFc01UZ3VNakVnVERrdU56SXNNVGd1TXpjZ1RERXdMakUyTERFNExqUTVJRXd4TUM0Mk1Dd3hPQzQyTUNCTU1URXVNRFVzTVRndU5qZ2dUREV4TGpRNUxERTRMamMwSUV3eE1TNDVNaXd4T0M0M055Qk1NVEl1TXpRc01UZ3VOemNnVERFeUxqYzBMREU0TGpjMUlFd3hNeTR4TXl3eE9DNDNNQ0JNTVRNdU5Ea3NNVGd1TmpJZ1RERXpMamd6TERFNExqVXhJRXd4TkM0eE5Td3hPQzR6TmlCTU1UUXVORFVzTVRndU1UZ2dUREUwTGpjeUxERTNMamszSUV3eE5DNDVOeXd4Tnk0M015Qk1NVFV1TVRrc01UY3VORFlnVERFMUxqTTRMREUzTGpFM0lFd3hOUzQxTlN3eE5pNDROU0JNTVRVdU5qZ3NNVFl1TlRNZ1RERTFMamM1TERFMkxqRTVJRXd4TlM0NE5pd3hOUzQ0TmlCTU1UVXVPRGtzTVRVdU5UTWdUREUxTGpnNUxERTFMakl3SUV3eE5TNDROaXd4TkM0NE9TQk1NVFV1Tnprc01UUXVOVGtnVERFMUxqWTVMREUwTGpNeElFd3hOUzQxTnl3eE5DNHdOQ0JNTVRVdU5ERXNNVE11TnprZ1RERTFMakl6TERFekxqVTFJRXd4TlM0d01pd3hNeTR6TkNCTU1UUXVPREFzTVRNdU1UUWdUREUwTGpVMUxERXlMamsySUV3eE5DNHdNaXd4TWk0Mk5TQk1NVE11TkRZc01USXVNemtnVERFeUxqTXlMREV4TGprNElFd3hNUzQ0TVN3eE1TNDNOeUJNTVRFdU5UZ3NNVEV1TmpVZ1RERXhMak00TERFeExqVXhJRXd4TVM0eU1Td3hNUzR6TlNCTU1URXVNRGdzTVRFdU1UY2dUREV3TGprM0xERXdMamszSUV3eE1DNDVNQ3d4TUM0M05TQk1NVEF1T0RZc01UQXVOVEVnVERFd0xqZzFMREV3TGpJMUlFd3hNQzQ0Tnl3NUxqazRJRXd4TUM0NU1TdzVMamN3SUV3eE1TNHdOQ3c1TGpFeUlFd3hNUzR5TXl3NExqVTJJRXd4TVM0ME5pdzRMakF6SUV3eE1TNDNNU3czTGpVMklFd3hNUzQ1Tnl3M0xqRTFJRXd4TWk0eU15dzJMamd4SUV3eE1pNDBPU3cyTGpVMUlFd3hNaTQzTVN3MkxqTTJJRXd4TWk0NU1TdzJMakl6SUV3eE15NHhPU3cyTGpBNUlFd3hNeTR6T1N3MkxqQTNJRXd4TXk0ME9DdzJMakE0V2lJZ2VpMXBibVJsZUQwaU1TSWdZMnhoYzNNOUltWnBiR3d0Y21Wa0lpOFx1MDAyQkNqeHdZWFJvSUdROUlpQk5OREl1TURBc01UVXVNRGdnVERReUxqQTBMREUxTGpFMklFdzBNaTR3TlN3eE5TNHpNeUJNTkRJdU1EQXNNVFV1TlRjZ1REUXhMamc1TERFMUxqZ3pJRXcwTVM0M01Dd3hOaTR4TUNCTU5ERXVORGNzTVRZdU16Y2dURFF4TGpNNUxERTJMalV3SUV3ME1TNHpOU3d4Tmk0Mk15Qk1OREV1TXpZc01UWXVOelFnVERReExqUTBMREUyTGpneklFdzBNUzQxTnl3eE5pNDRPU0JNTkRFdU56VXNNVFl1T1RBZ1REUXhMamszTERFMkxqZzFJRXcwTWk0eU1Td3hOaTQzTXlCTU5ESXVORFlzTVRZdU5UUWdURFF5TGpjd0xERTJMakk0SUV3ME1pNDVNU3d4TlM0NU55Qk1ORE11TURnc01UVXVOak1nVERRekxqRTRMREUxTGpJNElFdzBNeTR4T1N3eE5TNHhNaUJNTkRNdU1Ua3NNVFF1T1RZZ1REUXpMakUyTERFMExqZ3lJRXcwTXk0eE1Dd3hOQzQyT1NCTU5ETXVNRE1zTVRRdU5UZ2dURFF5TGprekxERTBMalE1SUV3ME1pNDRNaXd4TkM0ME1pQk1OREl1Tmprc01UUXVNellnVERReUxqVTFMREUwTGpNeklFdzBNaTQwTUN3eE5DNHpNU0JNTkRJdU1EY3NNVFF1TXpRZ1REUXhMamN6TERFMExqUTBJRXcwTVM0ek9Td3hOQzQyTVNCTU5ERXVNRGNzTVRRdU9ETWdURFF3TGpjNUxERTFMakV4SUV3ME1DNDFOQ3d4TlM0ME1pQk1OREF1TXpZc01UVXVOelFnVERRd0xqSTFMREUyTGpBMklFdzBNQzR5TVN3eE5pNHpOaUJNTkRBdU1qUXNNVFl1TmpNZ1REUXdMak0wTERFMkxqZzJJRXcwTUM0MU1Dd3hOeTR3TlNCTU5EQXVOekVzTVRjdU1Ua2dURFF3TGprMExERTNMak14SUV3ME1TNDBNaXd4Tnk0ME9TQk1OREV1T0RBc01UY3VOamdnVERReExqazBMREUzTGpjM0lFdzBNaTR3TkN3eE55NDROeUJNTkRJdU1Ea3NNVGN1T1RjZ1REUXlMakV4TERFNExqQTJJRXcwTWk0eE1Dd3hPQzR4TkNCTU5ESXVNRFFzTVRndU1qQWdURFF4TGprMkxERTRMakkxSUV3ME1TNDROU3d4T0M0eU55Qk1OREV1TnpFc01UZ3VNamdnVERReExqVTFMREU0TGpJMUlFdzBNUzR4T0N3eE9DNHhOQ0JNTkRBdU9ERXNNVGN1T1RjZ1REUXdMalV3TERFM0xqYzNJRXcwTUM0ek9Td3hOeTQyTnlCTU5EQXVNekFzTVRjdU5UWWdURFF3TGpFd0xERTNMakUxSUV3ME1DNHdOU3d4Tnk0eE1TQk1Nemt1T1Rrc01UY3VNRGtnVERNNUxqa3pMREUzTGpFd0lFd3pPUzQ0Tml3eE55NHhNeUJNTXprdU9EQXNNVGN1TVRrZ1RETTVMamMwTERFM0xqSTRJRXd6T1M0Mk5Td3hOeTQxTkNCTU16a3VOakVzTVRjdU9USWdURE01TGpZeUxERTRMakUwSUV3ek9TNDJOaXd4T0M0ek55Qk1Nemt1TnpRc01UZ3VOVGtnVERNNUxqZzJMREU0TGpnd0lFdzBNQzR3TkN3eE9DNDVPQ0JNTkRBdU1qWXNNVGt1TVRRZ1REUXdMalV5TERFNUxqSTNJRXcwTUM0NE1Td3hPUzR6TnlCTU5ERXVNVElzTVRrdU5EUWdURFF4TGpReUxERTVMalEzSUV3ME1TNDNNU3d4T1M0ME5pQk1OREV1T1Rjc01Ua3VOREVnVERReUxqSXdMREU1TGpNeklFdzBNaTR6T1N3eE9TNHhPU0JNTkRJdU5UWXNNVGt1TURFZ1REUXlMalk0TERFNExqZ3dJRXcwTWk0M05pd3hPQzQxTnlCTU5ESXVPREFzTVRndU16UWdURFF5TGpjNUxERTRMakV5SUV3ME1pNDNNeXd4Tnk0NU1pQk1OREl1TmpNc01UY3VOelFnVERReUxqVXdMREUzTGpVNUlFdzBNaTR6TkN3eE55NDBOU0JNTkRJdU1UVXNNVGN1TXpVZ1REUXhMak00TERFM0xqQTBJRXcwTVM0eU5Dd3hOaTQ1TlNCTU5ERXVNVE1zTVRZdU9ETWdURFF4TGpBM0xERTJMalk1SUV3ME1TNHdOU3d4Tmk0MU1TQk1OREV1TURjc01UWXVNeklnVERReExqRXlMREUyTGpFeUlFdzBNUzR5Tml3eE5TNDNOU0JNTkRFdU5EUXNNVFV1TkRRZ1REUXhMall5TERFMUxqSXpJRXcwTVM0M055d3hOUzR4TWlCTU5ERXVPRFlzTVRVdU1EY2dURFF4TGprekxERTFMakEzV2lJZ2VpMXBibVJsZUQwaU1TSWdZMnhoYzNNOUltWnBiR3d0Y21Wa0lpOFx1MDAyQkNqeHdZWFJvSUdROUlpQk5OVEl1TWpBc01UY3VOVFVnVERVeUxqUTJMREUzTGpVMElFdzFNaTQzTnl3eE55NDBPU0JNTlRNdU1USXNNVGN1TkRBZ1REVXpMalEyTERFM0xqSTJJRXcxTXk0NE1Dd3hOeTR3TlNCTU5UUXVNRGtzTVRZdU56Z2dURFUwTGpNMExERTJMalEzSUV3MU5DNDFOU3d4Tmk0eE5TQk1OVFF1Tmprc01UVXVPRGdnVERVMExqYzRMREUxTGpZeUlFdzFOQzQ0TVN3eE5TNHpPQ0JNTlRRdU56Z3NNVFV1TVRVZ1REVTBMalk0TERFMExqazNJRXcxTkM0MU15d3hOQzQ0TWlCTU5UUXVNek1zTVRRdU56RWdURFUwTGpBNUxERTBMalkzSUV3MU15NDRPQ3d4TkM0Mk9DQk1OVE11TmpZc01UUXVOeklnVERVekxqUXpMREUwTGpnd0lFdzFNeTR4T1N3eE5DNDVNaUJNTlRJdU9UWXNNVFV1TURZZ1REVXlMamN5TERFMUxqSXlJRXcxTWk0ME9Td3hOUzQwTVNCTU5USXVNamdzTVRVdU5qSWdURFV5TGpBMkxERTFMamcySUV3MU1TNDROaXd4Tmk0eE1TQk1OVEV1Tmpnc01UWXVNemNnVERVeExqVXlMREUyTGpZMUlFdzFNUzR6T1N3eE5pNDVNaUJNTlRFdU1qa3NNVGN1TWpBZ1REVXhMakl6TERFM0xqUTNJRXcxTVM0eE9Td3hOeTQzTkNCTU5URXVNVGtzTVRjdU9UUWdURFV4TGpJeExERTRMakV6SUV3MU1TNHlOU3d4T0M0ek1TQk1OVEV1TXpFc01UZ3VORGdnVERVeExqTTRMREU0TGpZMElFdzFNUzQwTnl3eE9DNDNPQ0JNTlRFdU5UZ3NNVGd1T1RFZ1REVXhMamN3TERFNUxqQXlJRXcxTVM0NE1pd3hPUzR4TUNCTU5URXVPVFlzTVRrdU1UY2dURFV5TGpJMkxERTVMakkySUV3MU1pNDFPQ3d4T1M0eU55Qk1OVEl1T1RJc01Ua3VNak1nVERVekxqRTBMREU1TGpFM0lFdzFNeTR6TlN3eE9TNHdPU0JNTlRNdU56Y3NNVGd1T0RjZ1REVTBMakU0TERFNExqWXdJRXcxTkM0MU5Td3hPQzR5T0NCTU5UUXVPRFVzTVRjdU9UZ2dURFUxTGpVNExERTNMakV4SUV3MU5TNDJNeXd4Tnk0d01DQk1OVFV1TmpJc01UWXVPVEVnVERVMUxqVTNMREUyTGpneklFdzFOUzQwTnl3eE5pNDRNaUJNTlRVdU16WXNNVFl1T0RVZ1REVTFMakl3TERFM0xqQXpJRXcxTkM0NE9Dd3hOeTR6TXlCTU5UUXVOREVzTVRjdU5qY2dURFV6TGpnNExERTNMamszSUV3MU15NDJNeXd4T0M0d09DQk1OVE11TXpnc01UZ3VNVFlnVERVekxqQTJMREU0TGpJeUlFdzFNaTQ1TVN3eE9DNHlNU0JNTlRJdU56Z3NNVGd1TVRrZ1REVXlMalk1TERFNExqRTFJRXcxTWk0Mk1Td3hPQzR3T1NCTU5USXVOVFFzTVRndU1ERWdURFV5TGpRNExERTNMamt4SUV3MU1pNDBNeXd4Tnk0M01DQk1OVEl1TkRFc01UY3VORE1nVERVeUxqUTBMREUzTGpFMElFdzFNaTQxTUN3eE5pNDRNeUJNTlRJdU5qSXNNVFl1TlRBZ1REVXlMamM0TERFMkxqRTVJRXcxTWk0NU5Dd3hOUzQ1TVNCTU5UTXVNVEVzTVRVdU5qZ2dURFV6TGpJM0xERTFMalV3SUV3MU15NHpOU3d4TlM0ME5TQk1OVE11TkRNc01UVXVORE1nVERVekxqUTVMREUxTGpRMElFdzFNeTQxTlN3eE5TNDBPQ0JNTlRNdU5qQXNNVFV1TlRRZ1REVXpMall6TERFMUxqWXhJRXcxTXk0Mk15d3hOUzQzTUNCTU5UTXVOaklzTVRVdU9EQWdURFV6TGpVekxERTJMakF5SUV3MU15NHpPQ3d4Tmk0eU5TQk1OVE11TWpBc01UWXVORGtnVERVeUxqazNMREUyTGpjeElFdzFNaTQzTkN3eE5pNDVNQ0JNTlRJdU5URXNNVGN1TURVZ1REVXlMak13TERFM0xqRTFJRXcxTWk0d01pd3hOeTR5TlNCTU5URXVPVFlzTVRjdU1qa2dURFV4TGpreUxERTNMak01SUV3MU1TNDVOQ3d4Tnk0ME9DQk1OVEV1T1Rnc01UY3VOVEVnVERVeUxqQXpMREUzTGpVMFdpSWdlaTFwYm1SbGVEMGlNU0lnWTJ4aGMzTTlJbVpwYkd3dGNtVmtJaThcdTAwMkJDanh3WVhSb0lHUTlJaUJOTlRBdU5qa3NNVGt1TXpFZ1REVXdMalExTERFNUxqSTBJRXcxTUM0eE9Td3hPUzR4TkNCTU5Ea3VPVFFzTVRndU9UZ2dURFE1TGpnMExERTRMamc0SUV3ME9TNDNOU3d4T0M0M05pQk1ORGt1Tmpjc01UZ3VOVGNnVERRNUxqWXpMREU0TGpNeklFdzBPUzQyTVN3eE9DNHdOeUJNTkRrdU5qSXNNVGN1TnpnZ1REUTVMalk0TERFM0xqTXpJRXcwT1M0M09Dd3hOaTQ0TkNCTU5UQXVNRE1zTVRVdU9EVWdURFV3TGpNd0xERTBMamt6SUV3MU1DNDJNaXd4TkM0d015Qk1OVEV1TURBc01UTXVNVFFnVERVeExqTTRMREV5TGpRd0lFdzFNUzQxTml3eE1pNHhNaUJNTlRFdU56VXNNVEV1T1RFZ1REVXhMamt6TERFeExqYzRJRXcxTWk0eE5Td3hNUzQzTUNCTU5USXVNamdzTVRFdU5qY2dURFV5TGpReUxERXhMalkzSUV3MU1pNDFOeXd4TVM0Mk9DQk1OVEl1TnpFc01URXVOek1nVERVeUxqZzJMREV4TGpnd0lFdzFNeTR3TUN3eE1TNDRPU0JNTlRNdU1URXNNVEl1TURBZ1REVXpMakU1TERFeUxqRXhJRXcxTXk0eU5Td3hNaTR5TXlCTU5UTXVNalFzTVRJdU16UWdURFV6TGpFNExERXlMalF5SUV3MU15NHdPQ3d4TWk0MU15Qk1OVEl1Tnpnc01USXVPRGtnVERVeUxqUTBMREV6TGpReElFdzFNaTR3TlN3eE5DNHhOU0JNTlRFdU5qa3NNVFF1T1RFZ1REVXhMalF5TERFMUxqVTJJRXcxTVM0eE9Td3hOaTR5TUNCTU5UQXVPVGtzTVRZdU9EZ2dURFV3TGpnMUxERTNMalUwSUV3MU1DNDNPQ3d4T0M0d01TQk1OVEF1Tnpjc01UZ3VORFFnVERVd0xqZ3hMREU0TGpjMUlFdzFNQzQ0T1N3eE9DNDVPQ0JNTlRBdU9UY3NNVGt1TVRBZ1REVXdMamszTERFNUxqRTJJRXcxTUM0NU5Dd3hPUzR5TkNCTU5UQXVPRFlzTVRrdU16RWdURFV3TGpjNUxERTVMak16V2lJZ2VpMXBibVJsZUQwaU1TSWdZMnhoYzNNOUltWnBiR3d0Y21Wa0lpOFx1MDAyQkNqeHdZWFJvSUdROUlpQk5ORFl1TlRJc01qQXVPVEFnVERRMkxqTXhMREl3TGpneElFdzBOaTR5TUN3eU1DNDNNeUJNTkRZdU1UQXNNakF1TmpRZ1REUTJMakEwTERJd0xqVTBJRXcwTmk0d01Td3lNQzQwTXlCTU5EWXVNREVzTWpBdU1qQWdURFEyTGpBM0xERTVMams1SUV3ME5pNHhPQ3d4T1M0NE1TQk1ORFl1TWpjc01Ua3VOekVnVERRMkxqTTVMREU1TGpZeklFdzBOaTQxTkN3eE9TNDFOU0JNTkRZdU56QXNNVGt1TkRrZ1REUTJMamsyTERFNUxqUXpJRXcwTnk0eU15d3hPUzR6T1NCTU5EY3VOemdzTVRrdU16VWdURFE0TGpFMkxERTVMak0xSUV3ME9DNDFNQ3d4T1M0ek9TQk1ORGd1T0RFc01Ua3VOVEFnVERRNExqazFMREU1TGpVNElFdzBPUzR3Tnl3eE9TNDJPU0JNTkRrdU1UVXNNVGt1T0RJZ1REUTVMakl3TERFNUxqazNJRXcwT1M0eU5pd3lNQzR6TUNCTU5Ea3VNallzTWpBdU5qSWdURFE1TGpJMExESXdMamM0SUV3ME9TNHhPU3d5TUM0NU5TQk1ORGt1TURjc01qRXVNakVnVERRNExqa3hMREl4TGpRNElFdzBPQzQzTUN3eU1TNDNOU0JNTkRndU5EVXNNakl1TURBZ1REUTRMakU0TERJeUxqSXlJRXcwTnk0NE9Dd3lNaTQwTUNCTU5EY3VOVFlzTWpJdU5UUWdURFEzTGpJekxESXlMalkxSUV3ME5pNDVNeXd5TWk0M01DQk1ORFl1TmpNc01qSXVOek1nVERRMkxqTTBMREl5TGpjeUlFdzBOaTR3T0N3eU1pNDJOeUJNTkRVdU9Ea3NNakl1TmpBZ1REUTFMamN6TERJeUxqVXhJRXcwTlM0MU9Td3lNaTQwTUNCTU5EVXVORFlzTWpJdU1qY2dURFExTGpNMUxESXlMakV5SUV3ME5TNHlOU3d5TVM0NU5DQk1ORFV1TVRnc01qRXVOelVnVERRMUxqRXpMREl4TGpVMUlFdzBOUzR4TUN3eU1TNHpNeUJNTkRVdU1Ea3NNakV1TVRJZ1REUTFMakV6TERJd0xqWTVJRXcwTlM0eE9Td3lNQzQwTUNCTU5EVXVNamNzTWpBdU1Ua2dURFExTGpNekxESXdMakV3SUV3ME5TNHlOU3d5TUM0d09DQk1ORFF1T0RJc01qQXVNRGtnVERRMExqRTNMREl3TGpFM0lFdzBNeTQyT1N3eU1DNHlPQ0JNTkRNdU1qRXNNakF1TkRNZ1REUXlMamN6TERJd0xqWXhJRXcwTUM0MU1Dd3lNUzQyTUNCTU16a3VPRElzTWpFdU9ETWdURE01TGpRNExESXhMamt5SUV3ek9TNHhOU3d5TVM0NU55Qk1Nemd1T0RZc01qSXVNREFnVERNNExqVTNMREl5TGpBd0lFd3pPQzR6TUN3eU1TNDVPQ0JNTXpndU1EUXNNakV1T1RRZ1RETTNMamcxTERJeExqZzRJRXd6Tnk0Mk9Dd3lNUzQ0TUNCTU16Y3VOVE1zTWpFdU56RWdURE0zTGpRd0xESXhMalU1SUV3ek55NHpNQ3d5TVM0ME5pQk1NemN1TWpJc01qRXVNeklnVERNM0xqRTJMREl4TGpFM0lFd3pOeTR4TWl3eU1TNHdNQ0JNTXpjdU1UQXNNakF1TmpnZ1RETTNMakV6TERJd0xqUXlJRXd6Tnk0eE55d3lNQzR6TXlCTU16Y3VNaklzTWpBdU1qZ2dURE0zTGpJNExESXdMakkySUV3ek55NHpNeXd5TUM0eU55Qk1NemN1TlRVc01qQXVNemdnVERNM0xqa3dMREl3TGpRNUlFd3pPQzR4TXl3eU1DNDFNeUJNTXpndU16a3NNakF1TlRVZ1RETTRMamd6TERJd0xqVTFJRXd6T1M0ek1Td3lNQzQxTVNCTU16a3VPREVzTWpBdU5EUWdURFF3TGpNeExESXdMak0wSUV3ME1pNHhOeXd4T1M0NE5TQk1OREl1T1Rrc01Ua3VOallnVERRekxqYzVMREU1TGpVeUlFdzBOQzQwTWl3eE9TNDBOU0JNTkRRdU9UWXNNVGt1TkRFZ1REUTFMakkxTERFNUxqUXlJRXcwTlM0MU1Dd3hPUzQwTmlCTU5EVXVOamtzTVRrdU5URWdURFExTGpnekxERTVMalU1SUV3ME5TNDRPU3d4T1M0Mk5TQk1ORFV1T1RFc01Ua3VOek1nVERRMUxqZzRMREU1TGpreklFdzBOUzQzTkN3eU1DNDBNeUJNTkRVdU56QXNNakF1TmpjZ1REUTFMamN6TERJd0xqa3dJRXcwTlM0NE1pd3lNUzR4TVNCTU5EVXVPRGdzTWpFdU1qQWdURFExTGprM0xESXhMakk0SUV3ME5pNHdPQ3d5TVM0ek5DQk1ORFl1TWpBc01qRXVNemtnVERRMkxqUTFMREl4TGpRMElFdzBOaTQzTWl3eU1TNDBOeUJNTkRjdU1ESXNNakV1TkRZZ1REUTNMak15TERJeExqUXdJRXcwTnk0Mk1Td3lNUzR6TVNCTU5EY3VPRGNzTWpFdU1UZ2dURFE0TGpFd0xESXhMakF6SUV3ME9DNHpNU3d5TUM0NE5pQk1ORGd1TlRVc01qQXVOVGtnVERRNExqY3dMREl3TGpNMUlFdzBPQzQzTkN3eU1DNHlNeUJNTkRndU56UXNNakF1TVRRZ1REUTRMalk1TERJd0xqQTRJRXcwT0M0MU9Td3lNQzR3TkNCTU5EZ3VNelFzTWpBdU1ETWdURFE0TGpBeExESXdMakExSUV3ME55NDJOU3d5TUM0eE1DQk1ORGN1TXpFc01qQXVNVGtnVERRM0xqRXpMREl3TGpJMklFdzBOaTQ1T0N3eU1DNHpOQ0JNTkRZdU56a3NNakF1TlRBZ1REUTJMamMwTERJd0xqVTVJRXcwTmk0Mk5pd3lNQzQ0TkNCTU5EWXVOakVzTWpBdU9URmFJaUI2TFdsdVpHVjRQU0l4SWlCamJHRnpjejBpWm1sc2JDMXlaV1FpTHo0S1BIQmhkR2dnWkQwaUlFMDBOeTQzTkN3eE55NDBNQ0JNTkRjdU5qUXNNVGN1TnpZZ1REUTNMalV3TERFNExqRXdJRXcwTnk0ek1pd3hPQzQwTXlCTU5EY3VNVEVzTVRndU56a2dURFEyTGpreExERTVMakF6SUV3ME5pNDJNeXd4T1M0eU1pQk1ORFl1TmpFc01Ua3VNamNnVERRMkxqWXhMREU1TGpNeUlFdzBOaTQyTXl3eE9TNHpPQ0JNTkRZdU5qY3NNVGt1TkRJZ1REUTJMamMwTERFNUxqUTJJRXcwTmk0NE15d3hPUzQwT0NCTU5EWXVPVGdzTVRrdU5EZ2dURFEzTGpFMUxERTVMalEySUV3ME55NHpNaXd4T1M0ME1TQk1ORGN1TkRrc01Ua3VNelFnVERRM0xqY3pMREU1TGpJd0lFdzBOeTQ1TlN3eE9TNHdNQ0JNTkRndU1UY3NNVGd1TnpZZ1REUTRMak00TERFNExqUTNJRXcwT0M0Mk1Dd3hPQzR4TVNCTU5EZ3VPREVzTVRjdU56TWdURFE1TGpFMkxERTJMamsxSUV3ME9TNDBNU3d4Tmk0eU5TQk1ORGt1TlRrc01UVXVOaklnVERRNUxqWXpMREUxTGpReElFdzBPUzQyTXl3eE5TNHlOQ0JNTkRrdU5qQXNNVFV1TVRFZ1REUTVMalUwTERFMUxqQXlJRXcwT1M0ek9Dd3hOQzQ1TWlCTU5Ea3VNVFlzTVRRdU9ETWdURFE0TGprekxERTBMamM0SUV3ME9DNDNNQ3d4TkM0NE1TQk1ORGd1TlRrc01UUXVPRFlnVERRNExqVXdMREUwTGpreElFdzBPQzQwTlN3eE5DNDVPQ0JNTkRndU5ERXNNVFV1TURZZ1REUTRMak15TERFMUxqVTRJRXcwT0M0eU5pd3hOUzQzTnlCTU5EZ3VNVGNzTVRVdU9UZ2dURFEzTGpreExERTJMalF5SUV3ME55NDFOeXd4Tmk0NU15Qk1ORGN1TVRrc01UY3VORFVnVERRM0xqQXdMREUzTGpZNElFdzBOaTQ0TXl3eE55NDRNeUJNTkRZdU5qa3NNVGN1T1RFZ1REUTJMalUzTERFM0xqa3hJRXcwTmk0ME9Td3hOeTQ0TkNCTU5EWXVORFVzTVRjdU56RWdURFEyTGpRekxERTNMalUxSUV3ME5pNDBOQ3d4Tnk0ek5TQk1ORFl1TlRNc01UWXVPVElnVERRMkxqWTVMREUyTGpReUlFdzBOaTQ1TVN3eE5TNDVOU0JNTkRjdU1qQXNNVFV1TkRrZ1REUTNMakkwTERFMUxqTTNJRXcwTnk0eU5Td3hOUzR5TmlCTU5EY3VNakVzTVRVdU1UVWdURFEzTGpBNExERTBMamszSUV3ME5pNDRPQ3d4TkM0NE1TQk1ORFl1Tmpjc01UUXVOekVnVERRMkxqUTJMREUwTGpZMklFdzBOaTR6Tnl3eE5DNDJOeUJNTkRZdU1qa3NNVFF1TmprZ1REUTJMakkwTERFMExqYzBJRXcwTlM0NE55d3hOUzQwTVNCTU5EVXVOVGNzTVRVdU9USWdURFExTGpRMUxERTJMakU0SUV3ME5TNHpOQ3d4Tmk0ME5TQk1ORFV1TVRRc01UY3VNVFVnVERRMUxqQTJMREUzTGpVMElFdzBOUzR3TUN3eE55NDVNeUJNTkRVdU1ERXNNVGd1TXpFZ1REUTFMakEwTERFNExqUTRJRXcwTlM0eE1Dd3hPQzQyTkNCTU5EVXVNVGdzTVRndU56Z2dURFExTGpJNUxERTRMamc1SUV3ME5TNDBNU3d4T0M0NU9TQk1ORFV1TlRVc01Ua3VNRFlnVERRMUxqZ3pMREU1TGpFMUlFdzBOaTR4TUN3eE9TNHhOaUJNTkRZdU16UXNNVGt1TVRFZ1REUTJMalUxTERFNUxqQXdJRXcwTmk0M01pd3hPQzQ0TkNCTU5EWXVPVEFzTVRndU5qUWdURFEzTGpJNUxERTRMakV5SUV3ME55NDFNaXd4Tnk0M09DQk1ORGN1TnpBc01UY3VORGRhSWlCNkxXbHVaR1Y0UFNJeElpQmpiR0Z6Y3owaVptbHNiQzF5WldRaUx6NEtQSEJoZEdnZ1pEMGlJRTAwTUM0NU9Td3hNUzQ0TnlCTU5ERXVNRFlzTVRFdU56WWdURFF4TGpFMkxERXhMalk1SUV3ME1TNHlNaXd4TVM0M01DQk1OREV1Tnpnc01USXVNREVnVERReUxqRTFMREV5TGpFMUlFdzBNaTQxTWl3eE1pNHlNeUJNTkRJdU9Ea3NNVEl1TWprZ1REUXpMalEyTERFeUxqTTBJRXcwTkM0d05Td3hNaTR6TmlCTU5EWXVOVGNzTVRJdU16Z2dURFEzTGpJMkxERXlMalEwSUV3ME55NDVPU3d4TWk0MU55Qk1ORGd1TWprc01USXVOallnVERRNExqVTRMREV5TGpjM0lFdzBPQzQzTUN3eE1pNDROQ0JNTkRndU9ERXNNVEl1T1RNZ1REUTRMamt3TERFekxqQXpJRXcwT0M0NU55d3hNeTR4TmlCTU5Ea3VNREVzTVRNdU1qZ2dURFE1TGpBekxERXpMalF5SUV3ME9TNHdNU3d4TXk0MU5TQk1ORGd1T1Rjc01UTXVOamdnVERRNExqZzVMREV6TGpneElFdzBPQzQzTnl3eE15NDVNQ0JNTkRndU5qTXNNVE11T1RZZ1REUTRMalEzTERFekxqazNJRXcwT0M0ek9Td3hNeTQ1TlNCTU5EZ3VNelFzTVRNdU56SWdURFE0TGpJNUxERXpMall6SUV3ME9DNHhNaXd4TXk0ME9TQk1ORGN1T0RZc01UTXVNelVnVERRM0xqWXdMREV6TGpJMElFdzBOeTR3Tml3eE15NHhNQ0JNTkRZdU5ETXNNVE11TURBZ1REUTFMamd3TERFeUxqazFJRXcwTlM0eE5pd3hNaTQ1TmlCTU5EUXVOVE1zTVRNdU1ESWdURFF6TGpBeExERXpMakk1SUV3ME1pNDBPU3d4TXk0ek5DQk1OREl1TWpBc01UTXVNelFnVERReExqa3dMREV6TGpNeUlFdzBNUzQyTWl3eE15NHlOU0JNTkRFdU16WXNNVE11TVRJZ1REUXhMakl4TERFekxqQXhJRXcwTVM0d09Dd3hNaTQ0TnlCTU5EQXVPVGNzTVRJdU56SWdURFF3TGprd0xERXlMalUxSUV3ME1DNDROeXd4TWk0ek9DQk1OREF1T0Rjc01USXVNakVnVERRd0xqa3hMREV5TGpBMFdpSWdlaTFwYm1SbGVEMGlNU0lnWTJ4aGMzTTlJbVpwYkd3dGNtVmtJaThcdTAwMkJDanh3WVhSb0lHUTlJaUJOTkRNdU5UUXNNVFl1TnpZZ1REUXpMamt5TERFMUxqWTVJRXcwTkM0ek5Td3hOQzQyTXlCTU5EUXVPVGtzTVRNdU1UY2dURFExTGpNeUxERXlMalV5SUV3ME5TNDFNaXd4TWk0eU1TQk1ORFV1TnpVc01URXVPVFFnVERRMUxqazVMREV4TGpjMklFdzBOaTR4Tnl3eE1TNDJPQ0JNTkRZdU16Y3NNVEV1TmpRZ1REUTJMalU0TERFeExqWTFJRXcwTmk0M09Dd3hNUzQzTUNCTU5EWXVPVE1zTVRFdU56WWdURFEzTGpBMkxERXhMamcwSUV3ME55NHhOeXd4TVM0NU5DQk1ORGN1TWpVc01USXVNRFlnVERRM0xqSTVMREV5TGpFMklFdzBOeTR6TUN3eE1pNHpNQ0JNTkRjdU1qY3NNVEl1TXpjZ1REUTJMams0TERFeUxqWXhJRXcwTmk0M055d3hNaTQ0TkNCTU5EWXVOVGdzTVRNdU1UQWdURFExTGprMUxERTBMakUxSUV3ME5TNDFOeXd4TkM0NU1pQk1ORFV1TVRjc01UVXVPRFFnVERRMExqWXpMREUzTGpJeElFdzBOQzQwT1N3eE55NDJOQ0JNTkRRdU5ERXNNVGd1TURnZ1REUTBMak01TERFNExqSTVJRXcwTkM0ek9Td3hPQzQxTUNCTU5EUXVORE1zTVRndU56SWdURFEwTGpVeUxERTRMamszSUV3ME5DNDFOU3d4T1M0d09TQk1ORFF1TlRNc01Ua3VNalVnVERRMExqVXdMREU1TGpJNElFdzBOQzQwTVN3eE9TNHpNeUJNTkRRdU16QXNNVGt1TXpVZ1REUTBMakUyTERFNUxqTTBJRXcwTkM0d01Td3hPUzR6TUNCTU5ETXVPRFlzTVRrdU1qTWdURFF6TGpjeExERTVMakUwSUV3ME15NDFPQ3d4T1M0d01TQk1ORE11TkRjc01UZ3VPRGdnVERRekxqTXpMREU0TGpZeElFdzBNeTR5Tml3eE9DNHpOQ0JNTkRNdU1qUXNNVGd1TURjZ1REUXpMakkyTERFM0xqZ3dJRXcwTXk0ek55d3hOeTR5TjFvaUlIb3RhVzVrWlhnOUlqRWlJR05zWVhOelBTSm1hV3hzTFhKbFpDSXZQZ29nSUNBZ1BDOXpkbWNcdTAwMkIiDQogICAgICB9DQogICAgfSwNCiAgICAiZ3JvdXAiOiAiU1ZHIiwNCiAgICAiaW5wdXRzIjogWw0KICAgICAgew0KICAgICAgICAibmFtZSI6ICJTVkciLA0KICAgICAgICAidHlwZSI6IHsNCiAgICAgICAgICAibmFtZSI6ICJTeXN0ZW0uQ29sbGVjdGlvbnMuR2VuZXJpYy5JTGlzdFx1MDA2MDFbW1N5c3RlbS5PYmplY3QsIFN5c3RlbS5Qcml2YXRlLkNvcmVMaWIsIFZlcnNpb249Ny4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj03Y2VjODVkN2JlYTc3OThlXV0iLA0KICAgICAgICAgICJhc3NlbWJseSI6ICJTeXN0ZW0uUHJpdmF0ZS5Db3JlTGliIg0KICAgICAgICB9LA0KICAgICAgICAicHJldHR5IjogIlNWRyIsDQogICAgICAgICJkZXNjIjogInJoaW5vc2NyaXB0c3ludGF4IGdlb21ldHJ5IiwNCiAgICAgICAgImFjY2VzcyI6ICJsaXN0Ig0KICAgICAgfSwNCiAgICAgIHsNCiAgICAgICAgIm5hbWUiOiAiQ1NTIiwNCiAgICAgICAgInR5cGUiOiB7DQogICAgICAgICAgIm5hbWUiOiAiU3lzdGVtLkNvbGxlY3Rpb25zLkdlbmVyaWMuSUxpc3RcdTAwNjAxW1tTeXN0ZW0uT2JqZWN0LCBTeXN0ZW0uUHJpdmF0ZS5Db3JlTGliLCBWZXJzaW9uPTcuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49N2NlYzg1ZDdiZWE3Nzk4ZV1dIiwNCiAgICAgICAgICAiYXNzZW1ibHkiOiAiU3lzdGVtLlByaXZhdGUuQ29yZUxpYiINCiAgICAgICAgfSwNCiAgICAgICAgInByZXR0eSI6ICJDU1MiLA0KICAgICAgICAiZGVzYyI6ICJyaGlub3NjcmlwdHN5bnRheCBnZW9tZXRyeSIsDQogICAgICAgICJhY2Nlc3MiOiAibGlzdCIsDQogICAgICAgICJlbWJlZGRlZERhdGEiOiAiYkU3dENvSkFFTHp5a2lqd0lYb0E2Ulg2QUlzZ3BLSy9jc2pTQ2JvbmUyc1EwYk9YSzByOWFHQmdaM1ptV1gxeWp0OHRSa29wWWJTaTNCWjN1QUw1d3FHczB0WVdqSHRHcWV3OEEvTFdzUGx0VHphdXdlNWUwRHZobWd6bWR1ai9EXHUwMDJCblVzQlZqMW9yZ3VYenBQVU1sSFVrSXBwZEhEVWRUd1pCYUpHUzh0NjZ1Z2VJREVFSVpTOGJIeVM0N014VjRtMk5UbHBudjV1RkpGWDYxbkZFZkFBQUEvLzhEQUE9PSINCiAgICAgIH0NCiAgICBdLA0KICAgICJvdXRwdXRzIjogWw0KICAgICAgew0KICAgICAgICAibmFtZSI6ICJTVkciLA0KICAgICAgICAidHlwZSI6IHsNCiAgICAgICAgICAibmFtZSI6ICJTeXN0ZW0uT2JqZWN0Ig0KICAgICAgICB9LA0KICAgICAgICAic3RyaWN0IjogZmFsc2UsDQogICAgICAgICJwcmV0dHkiOiAiU1ZHIiwNCiAgICAgICAgImRlc2MiOiAicmhpbm9zY3JpcHRzeW50YXggZ2VvbWV0cnkiDQogICAgICB9DQogICAgXQ0KICB9DQp9";
    readonly dynamic _script;

    public override Guid ComponentGuid { get; } = new Guid("ef5a6f3f-63b0-4c89-b503-d75075096ec3");

    public override GH_Exposure Exposure { get; } = GH_Exposure.primary;

    public override bool Obsolete { get; } = false;

    protected override SD.Bitmap Icon => _icon;

    public ProjectComponent_ef5a6f3f() : base(
        name: "StyleSVG",
        nickname: "StyleSVG",
        description: "",
        category: "Redback-Beta",
        subCategory: "SVG"
        )
    {
      bool success = ProjectComponentPlugin.TryCreateScript(this, _scriptData, out _script);
      if (success)
      {
        ProjectComponentPlugin.TryCreateScriptIcon(_script, out _icon);
      }
      else
      {
        AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Scripting platform is not ready.");
      }
    }

    protected override void RegisterInputParams(GH_InputParamManager _) { }

    protected override void RegisterOutputParams(GH_OutputParamManager _) { }

    protected override void BeforeSolveInstance()
    {
      if (_script is null) return;
      _script.BeforeSolve(this);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
      if (_script is null) return;
      _script.Solve(this, DA);
    }

    protected override void AfterSolveInstance()
    {
      if (_script is null) return;
      _script.AfterSolve(this);
    }

    public override void RemovedFromDocument(GH_Document document)
    {
      ProjectComponentPlugin.DisposeScript(this, _script);
      base.RemovedFromDocument(document);
    }

    public override BoundingBox ClippingBox
    {
      get
      {
        if (_script is null) return BoundingBox.Empty;
        return _script.GetClipBox(this);
      }
    }

    public override void DrawViewportWires(IGH_PreviewArgs args)
    {
      if (_script is null) return;
      _script.DrawWires(this, args);
    }

    public override void DrawViewportMeshes(IGH_PreviewArgs args)
    {
      if (_script is null) return;
      _script.DrawMeshes(this, args);
    }
  }
}
