using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Taxt : MonoBehaviour
{
    public UnityEvent _onClickEvent;

    private Vector3 startScale;

    public float scaleFactor = 1.5f; // ������ ��������� ������

    private void Awake()
    {
        startScale = transform.localScale; // �������� ���������� ����� ��'����
    }

    private void OnMouseEnter()
    {
        // �������� ����� ��'���� ��� �������� ����
        transform.localScale = startScale * scaleFactor;
    }

    private void OnMouseExit()
    {
        // ��������� ��'��� �� ���������� ������ ��� �������� ����
        transform.localScale = startScale;
    }

    private void OnMouseDown()
    {
        // ����� ��� ������� ��䳿 ���� ����, ���� �������
        _onClickEvent.Invoke();
    }
}
