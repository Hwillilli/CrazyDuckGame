using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Transform[] m_tfBackgrounds;
    [SerializeField] float m_speed = 0f;
    [SerializeField] float blank = 0f;

    float m_leftPosX = 0f;
    float m_rightPosX = 0f;

    private void Update()
    {

        float t_length = m_tfBackgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x + blank;
        m_leftPosX = -(t_length + blank);
        m_rightPosX = (t_length + blank * 2 - 0.1f) * m_tfBackgrounds.Length;

        for (int i = 0; i < m_tfBackgrounds.Length; i++)
        {
            m_tfBackgrounds[i].position += new Vector3(m_speed, 0, 0) * Time.deltaTime;

            if(m_tfBackgrounds[i].position.x < m_leftPosX)
            {
                Vector3 t_selfPos = m_tfBackgrounds[i].position;
                t_selfPos.Set(t_selfPos.x + m_rightPosX, t_selfPos.y, t_selfPos.z);
                m_tfBackgrounds[i].position = t_selfPos;
            }
        }
    }
}
